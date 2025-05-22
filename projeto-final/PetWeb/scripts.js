const baseUrl = "http://localhost:5118";
const getTutorEndpoint = "tutor";
const getPetsEndpoint = "tutor/{id}/pets";
const createPetEndpoint = "tutor/{id}/pets";
const getVacinasEndpoint = "pets/{id}/vacinas";
const createVacinaEndpoint = "pets/{id}/vacinas";
const getConsultasEndpoint = "pets/{id}/consultas";


const petItem = '<button id="pet-{id}" key="{id}" type="button" class="list-group-item list-group-item-action" aria-current="true" data-bs-toggle="list">{name}</button>';

(async () => {
    const notification = document.getElementById('liveToast')
    const toast = new bootstrap.Toast(notification)

    const tutor = await loadTutor(notification)
    let pets = []

    if (tutor) {
        pets = await renderizaPet(notification, tutor)

        if(pets) {
            vacinas = await renderizaVacinas(notification, pets[0])
        }

        const btnNewPet = document.getElementById('btnNewPet')
        btnNewPet.addEventListener('click', (e) => {
            const frmNewPet = document.getElementById('frmNewPet')
            
            frmNewPet.hidden = false
            const petList = document.getElementById("petList")

            const infoPet = document.getElementById("infoPet")
            infoPet.hidden = true

            Array.from(petList.children).forEach(i => {
                i.className = 'list-group-item list-group-item-action'
            })
        })

        const petForm = document.querySelector("#frmNewPet")

        petForm.addEventListener("submit", async e => {
            e.preventDefault()
            e.stopPropagation()

            if (petForm.checkValidity()) {
                const data = submitPet(notification, petForm, tutor)
            }

            petForm.classList.add('was-validated')

        })
    }
})()

async function submitPet(notification, form, tutor) {
    const data = formDataToJson(form);
    const response = await upsertPet(tutor.documento.numero, data);

    error = hasError(notification, response)

    if (error) {
        return
    }

    const parser = new DOMParser();
    const petList = document.getElementById("petList")

    const el = petItem.replace("{name}", response.nome).replaceAll("{id}", response.id);
    const doc = parser.parseFromString(el, 'text/html');
    petList.appendChild(doc.body.firstChild)
    petList.lastElementChild.className = `${petList.lastElementChild.className} active`;
    
    form.hidden = true
    form.reset()
    form.classList.remove('was-validated')
}

function formDataToJson(form) {
    const jsonData = {}
    for (const pair of new FormData(form)) {

        if (pair[0] === "especie") {
            jsonData[pair[0]] = Number(pair[1])
        } else {
            jsonData[pair[0]] = pair[1];
        }
    }

    return jsonData
}

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

function petAddEventoClick(notification, petButton, pet) {
    petButton.addEventListener('click', (e) => {
        renderizaVacinas(notification, pet)
    })
}

function renderPetList(notification, pets) {
    const parser = new DOMParser();
    const petList = document.getElementById("petList")

    Array.from(pets).forEach(pet => {
        const el = petItem.replace("{name}", pet.nome).replaceAll("{id}", pet.id);
        const doc = parser.parseFromString(el, 'text/html');
        petAddEventoClick(notification, doc.body.firstChild, pet)
        petList.appendChild(doc.body.firstChild)
    })

    return petList
}

async function renderizaPet(notification, tutor) {
    pets = await getPets(tutor.documento.numero)
    error = hasError(notification, pets)

    if (error) {
        return false
    }

    const petList = renderPetList(notification, pets)

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

        return true
    }

    return false
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

async function upsertPet(tutorID, pet) {
    const url = `${baseUrl}/${createPetEndpoint}`.replace("{id}", tutorID);

    return await fetch(url, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(pet)

    }).then(response => {
        if (response.status === 201) {
            return response.json();
        } else {
            return { status: response.status, error: response.statusText }
        }
    }).catch(error => {
        return { error: error }
    });
}

async function getVacinas(PetID) {
    const url = `${baseUrl}/${getVacinasEndpoint}`.replace("{id}", PetID);

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

async function renderizaVacinas(notification, pet) {
    var vacinas = await getVacinas(pet.id)
    error = hasError(notification, vacinas)

    if (error) {
        return false
    }

    const tbvacina = document.getElementById("tbVacina")
    .getElementsByTagName('tbody')[0]

    tbvacina.innerHTML = ''

    Array.from(vacinas).forEach((vac,i) => {
        const linha = tbvacina.insertRow(i)

        const colnome = linha.insertCell(0)
        const colDtAplic = linha.insertCell(1)
        const colDtVali = linha.insertCell(2)

        colnome.textContent = vac.nome
        colDtAplic.textContent = vac.dataDeAplicacao
        colDtVali.textContent = vac.dataDeValidade

    })
}

async function upsertVacina(PetId, vacina) {
    const url = `${baseUrl}/${createVacinaEndpoint}`.replace("{id}", PetId);

    return await fetch(url, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(vacina)

    }).then(response => {
        if (response.status === 201) {
            return response.json();
        } else {
            return { status: response.status, error: response.statusText }
        }
    }).catch(error => {
        return { error: error }
    });
}

async function getConsultas(PetID) {
    const url = `${baseUrl}/${getConsultasEndpoint}`.replace("{id}", PetID);

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