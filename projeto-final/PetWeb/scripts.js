const baseUrl = "http://localhost:5118";
const getTutorEndpoint = "tutor";
const getPetsEndpoint = "tutor/{id}/pets";
const createPetEndpoint = "tutor/{id}/pets";
const getVacinasEndpoint = "pets/{id}/vacinas";
const createVacinaEndpoint = "pets/{id}/vacinas";
const getConsultasEndpoint = "pets/{id}/consultas";
const createConsultaEndpoint = "pets/{id}/consultas";
const deletePetEndpoint = "tutor/{id}/pets/{petId}";
const deleteVacinaEndpoint = "pets/{id}/vacinas/{vacinaId}";
const deleteConsultaEndpoint = "pets/{id}/consultas/{consultaId}";

const petItem = '<button id="pet-{id}" key="{id}" type="button" class="list-group-item list-group-item-action" aria-current="true" data-bs-toggle="list">{name}</button>';

(async () => {
    const notification = document.getElementById('liveToast')
    const toast = new bootstrap.Toast(notification)

    const tutor = await loadTutor(notification)
    let pets = []

    const frmNewPet = document.getElementById('frmNewPet')
    const frmNewVac = document.getElementById('frmNewVac')
    const frmNewConsul = document.getElementById('frmNewConsul')
    const infoPet = document.getElementById("infoPet")

    if (tutor) {
        pets = await renderizaPet(notification, tutor)

        if (pets) {
            vacinas = await renderizaVacinas(notification, pets[0])

            consultas = await renderizaConsultas(notification, pets[0])
        }

        const btnNewPet = document.getElementById('btnNewPet')
        btnNewPet.addEventListener('click', (e) => {

            frmNewPet.hidden = false
            frmNewVac.hidden = true
            frmNewConsul.hidden = true
            infoPet.hidden = true

            const petList = document.getElementById("petList")
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

            frmNewPet.hidden = true
            infoPet.hidden = false
            petForm.classList.add('was-validated')
        })

        const btnNewVac = document.getElementById('btnNewVac')
        btnNewVac.addEventListener('click', (e) => {

            frmNewVac.hidden = false
            frmNewVac.classList.remove('was-validated')

            infoPet.hidden = true

            const tbVacina = document.getElementById("tbVacina")
            Array.from(tbVacina.rows).forEach(row => {
                row.classList.add('table-row-class');
            });
        })

        const vacForm = document.querySelector("#frmNewVac")

        vacForm.addEventListener("submit", async e => {
            e.preventDefault()
            e.stopPropagation()

            const txtPetId = document.querySelector("#txtPetId")
            if (vacForm.checkValidity()) {
                const data = await submitVac(notification, vacForm, txtPetId.textContent)

                frmNewVac.hidden = true
                infoPet.hidden = false
                vacForm.reset()
            }
        })


        // const deleteBtnVac = document.createElement('button');
        // deleteBtnVac.className = 'btn btn-sm btn-outline-danger'; deleteBtnVac.className = 'btn btn-sm btn-outline-danger';
        // deleteBtnVac.textContent = '×'; deleteBtnVac.textContent = '×';
        // deleteBtnVac.setAttribute('data-vacina-id', vac.id); deleteBtnVac.setAttribute('data-vacina-id', vac.id);
        // colActions.appendChild(deleteBtnVac); colActions.appendChild(deleteBtnVac);

        // deleteBtnVac.addEventListener('click', async (e) => {
        //     e.stopPropagation();
        //     const confirmed = confirm('Tem certeza que deseja excluir esta vacina?');
        //     if (confirmed) {
        //         const success = await deleteVacina(pet.id, vac.id, notification);
        //         if (success) {
        //             linha.remove();
        //         }
        //     }
        // });

        const btnNewConsul = document.getElementById('btnNewConsul')
        btnNewConsul.addEventListener('click', (e) => {

            frmNewConsul.hidden = false
            infoPet.hidden = true
        })

        const consulForm = document.querySelector("#frmNewConsul")
        consulForm.addEventListener("submit", async e => {
            e.preventDefault()
            e.stopPropagation()

            const txtPetId = document.querySelector("#txtPetId")

            if (consulForm.checkValidity()) {
                const data = submitConsul(notification, consulForm, txtPetId.textContent)
            }

            frmNewConsul.hidden = true
            infoPet.hidden = false
            consulForm.classList.add('was-validated')

        })
        // const deleteBtnConsult = document.createElement('button');
        // deleteBtnConsult.className = 'btn btn-sm btn-outline-danger'; deleteBtnConsult.className = 'btn btn-sm btn-outline-danger';
        // deleteBtnConsult.textContent = '×'; deleteBtnConsult.textContent = '×';
        // deleteBtnConsult.setAttribute('data-consulta-id', consulta.id); deleteBtnConsult.setAttribute('data-consulta-id', consulta.id);
        // colActions.appendChild(deleteBtnConsult); colActions.appendChild(deleteBtnConsult);


        // deleteBtn.addEventListener('click', async (e) => {
        //     e.stopPropagation();
        //     const confirmed = confirm('Tem certeza que deseja excluir esta consulta?');
        //     if (confirmed) {
        //         const success = await deleteConsulta(pet.id, consulta.id, notification);
        //         if (success) {
        //             linha.remove();
        //         }
        //     }
        // });

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

async function submitVac(notification, form, petId) {
    const data = formDataToJson(form);
    const response = await upsertVacina(petId, data);
    error = hasError(notification, response)
    if (error) {
        return
    }

    renderizaVacinas(notification, { id: petId })

    form.hidden = true
    form.reset()
    form.classList.remove('was-validated')
}

async function submitConsul(notification, form, petID) {
    const data = formDataToJson(form);
    const response = await upsertConsulta(petID, data);
    error = hasError(notification, response)
    if (error) {
        return
    }

    renderizaConsultas(notification, {id: petID})

    doc.body.firstChild.querySelector("txtVacinaId").addEventListener('click', async (e) => {
        e.stopPropagation();
        if (confirm('Tem certeza que deseja excluir esta vacina?')) {
            const vacinaId = e.currentTarget.getAttribute('data-vacina-id');
            const success = await deleteVacina(pet.id, vacinaId, notification);
            if (success) {
                e.currentTarget.closest('tr').remove();
            }
        }
    });

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
        renderizaConsultas(notification, pet)
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
async function deletePet(tutorId, petId, notification) {
    const url = `${baseUrl}/${getPetsEndpoint.replace("{id}", tutorId)}/${petId}`;
    const response = await fetch(url, {
        method: "DELETE",
        headers: {
            "Content-Type": "application/json"
        }
    }).then(response => {
        if (response.status === 204) {
            return { success: true };
        } else {
            return { status: response.status, error: response.statusText };
        }
    }).catch(error => {
        return { error: error };
    });

    const error = hasError(notification, response);
    return !error;
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

    const txtPetId = document.querySelector("#txtPetId")
    txtPetId.textContent = pet.id

    var vacinas = await getVacinas(pet.id)
    error = hasError(notification, vacinas)

    if (error) {
        return false
    }

    const tbvacina = document.getElementById("tbVacina")
        .getElementsByTagName('tbody')[0]

    tbvacina.innerHTML = ""

    Array.from(vacinas).forEach((vac, i) => {
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

async function deleteVacina(petId, vacinaId, notification) {
    const url = `${baseUrl}/${getVacinasEndpoint.replace("{id}", petId)}/${vacinaId}`;

    const response = await fetch(url, {
        method: "DELETE",
        headers: {
            "Content-Type": "application/json"
        }
    }).then(response => {
        if (response.status === 204) {
            return { success: true };
        } else {
            return { status: response.status, error: response.statusText };
        }
    }).catch(error => {
        return { error: error };
    });

    const error = hasError(notification, response);
    return !error;
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

async function renderizaConsultas(notification, pet) {
    const txtPetId = document.querySelector("#txtPetId")
    txtPetId.textContent = pet.id

    var consulta = await getConsultas(pet.id)
    error = hasError(notification, consulta)

    if (error) {
        return false
    }

    const tbconsulta = document.getElementById("tbConsulta")
        .getElementsByTagName('tbody')[0]

    tbconsulta.innerHTML = ''

    Array.from(consulta).forEach((consulta, i) => {
        const linha = tbconsulta.insertRow(i)

        const colnomeDoutor = linha.insertCell(0)
        const colDtConsulta = linha.insertCell(1)
        const colDiagnostico = linha.insertCell(2)

        colnomeDoutor.textContent = consulta.nomeDoutor
        colDtConsulta.textContent = consulta.dataConsulta
        colDiagnostico.textContent = consulta.diagnostico
    })
}

async function upsertConsulta(PetId, consulta) {
    const url = `${baseUrl}/${createConsultaEndpoint}`.replace("{id}", PetId);

    return await fetch(url, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(consulta)

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

async function deleteConsulta(petId, consultaId, notification) {
    const url = `${baseUrl}/${getConsultasEndpoint.replace("{id}", petId)}/${consultaId}`;

    const response = await fetch(url, {
        method: "DELETE",
        headers: {
            "Content-Type": "application/json"
        }
    }).then(response => {
        if (response.status === 204) {
            return { success: true };
        } else {
            return { status: response.status, error: response.statusText };
        }
    }).catch(error => {
        return { error: error };
    });

    const error = hasError(notification, response);
    return !error;
}


