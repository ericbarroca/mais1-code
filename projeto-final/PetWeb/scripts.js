const baseUrl = "http://localhost:5118";
const getTutorEndpoint = "tutor";
const getPetsEndpoint = "tutor/{id}/pets";

const petItem = '<button key="{id}" type="button" class="list-group-item list-group-item-action " aria-current="true">{name}</button>';

(async () => {

    const notification = document.getElementById('liveToast')
    const toast = new bootstrap.Toast(notification)

    const tutor = await loadTutor(notification)
    let pets = []

    if(tutor) {
        pets = await renderizaPet(notification, tutor)
    }



})()

async function loadTutor(notification) {
    tutor = await getTutor(123456789);
    error = hasError(notification, tutor)

    if (error) {
        return false
    }

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
        const el = petItem.replace("{name}", pet.nome).replace("{id}", pet.id);
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
    } else {
        usernameElement = document.getElementById('userName')
        usernameElement.textContent = data.nome
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