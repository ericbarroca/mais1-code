(() => {
    'use strict'

    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    const form = document.querySelector("#LoginForm")

    form.addEventListener("submit", async e => {
        e.preventDefault();

        const alert = document.querySelector("#error")
        alert.className = "invisible";

        const error = await submitForm(e, form)

        console.log(error)
        if(error) {
            alert.className = "alert alert-danger";
            alert.textContent = error;
        } else {
            alert.className = "alert alert-success";
            alert.textContent = "Login realizado com sucesso";
        }
     })
})()

async function submitForm(e, form) {
    const data = formDataToJson(form);

    const response = await login(data);

    return response.error;
}

function formDataToJson(form) {
    const jsonData = {}
    for(const pair of new FormData(form)) {
        jsonData[pair[0]] = pair[1];
    }

    return jsonData
}

async function login(data) {
    const url = "http://localhost:5257/login";

    return await fetch(url, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(data)
    }).then(response=> {
        console.log("Dados enviados:", response);

        if(response.status === 201) {
            return response.json(); 
        } else {
            return {error: "Erro de Login"}
        }
    }).catch(error=>{
        console.error("Erro ao enviar dados:", error);
    });
    
}