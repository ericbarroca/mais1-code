const baseUrl = "http://localhost:5118";
const getTutorEndpoint = "tutor";
const getPetsEndpoint = "tutor/{id}/pets";

const petItem = '<button id="pet-{id}" key="{id}" type="button" class="list-group-item list-group-item-action" aria-current="true" data-bs-toggle="list">{name}</button>';

(async () => {

    const forms = document.querySelectorAll('.needs-validation')

    // Loop over them and prevent submission
    Array.from(forms).forEach(form => {
      form.addEventListener('submit', event => {
        if (!form.checkValidity()) {
          event.preventDefault()
          event.stopPropagation()
        }
  
        form.classList.add('was-validated')
      }, false)
    })

    const notification = document.getElementById('liveToast')
    const toast = new bootstrap.Toast(notification)

    const tutor = await loadTutor(notification)
    let pets = []

    if(tutor) {
        pets = await renderizaPet(notification, tutor)

        const btnNewPet = document.getElementById('btnNewPet')
        btnNewPet.addEventListener('click', (e)=> {
            const frmNewPet = document.getElementById('frmNewPet')
            frmNewPet.hidden = false

            const petList = document.getElementById("petList")
            Array.from(petList.children).forEach(i=>{
                i.className = 'list-group-item list-group-item-action'
            })
        })
    }



})()

async function loadTutor(notification) {
    tutor = await getTutor(123456789);
    error = hasError(notification, tutor)

    if (error) {
        return false
    }

    const userName = document.getElementById("userName")
    userName.textContent = tutor.nome

    return tutor
}

async function renderizaPet(notification, tutor) {
    pets = await getPets(tutor.documento.numero)
    error = hasError(notification, pets)

    if (error) {
        return false
    }

    const parser = new DOMParser();
    const petList = document.getElementById("petList")

    Array.from(pets).forEach(pet => {
        const el = petItem.replace("{name}", pet.nome).replaceAll("{id}", pet.id);
        const doc = parser.parseFromString(el, 'text/html');
        petList.appendChild(doc.body.firstChild)
    })

    petList.firstElementChild.className = `${petList.firstElementChild.className} active`;

    return pets
}

function hasError(notification, data) {
    if (data.error) {
        toastTitle = notification.querySelector('#toastTitle')
        toastBody = notification.querySelector(".toast-body")

        toastTitle.textContent = "Erro"
        toastBody.textContent = data.error
        toast.show()
    }
}

async function getTutor(id) {

    const url = `${baseUrl}/${getTutorEndpoint}/${id}`;

    return await fetch(url, {
        method: "GET",
        headers: {
            "Content-Type": "application/json"
        },

    }).then(response => {
        if (response.status === 200) {
            return response.json();
        } else {
            return { status: response.status, error: response.statusText }
        }
    }).catch(error => {
        return { error: error }
    });
}

async function getPets(tutorID) {

    const url = `${baseUrl}/${getPetsEndpoint}`.replace("{id}", tutorID);

    return await fetch(url, {
        method: "GET",
        headers: {
            "Content-Type": "application/json"
        },

    }).then(response => {
        if (response.status === 200) {
            return response.json();
        } else {
            return { status: response.status, error: response.statusText }
        }
    }).catch(error => {
        return { error: error }
    });
}