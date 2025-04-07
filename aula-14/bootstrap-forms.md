# Bootstrap Forms

Em HTML `<form>` são elementos que agrupam elementos de iteração do usuário e permitem o envio de dados a apis. Com bootstrap podemos extender o uso dos formulários com as classes providas. Veja o exemplo abaixo:

```html
<form>
  <div class="mb-3">
    <label for="exampleInputEmail1" class="form-label">Email address</label>
    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
    <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div>
  </div>
  <div class="mb-3">
    <label for="exampleInputPassword1" class="form-label">Password</label>
    <input type="password" class="form-control" id="exampleInputPassword1">
  </div>
  <div class="mb-3 form-check">
    <input type="checkbox" class="form-check-input" id="exampleCheck1">
    <label class="form-check-label" for="exampleCheck1">Check me out</label>
  </div>
  <button type="submit" class="btn btn-primary">Submit</button>
</form>
```

Com eles criamos um formulário simples de login e usamos das seguintes classes do bootstrap:
- `form-label`: Para estilizar labels de inputs
- `form-control`: Para estilizar inputs
- `form-check-input`: Para inputs que são checkboxes.

Podemos usar também descrições para nossos campos que vão além das labels através da classe `form-text`:

```html
<div class="row g-3 align-items-center">
  <div class="col-auto">
    <label for="inputPassword6" class="col-form-label">Password</label>
  </div>
  <div class="col-auto">
    <input type="password" id="inputPassword6" class="form-control" aria-describedby="passwordHelpInline">
  </div>
  <div class="col-auto">
    <span id="passwordHelpInline" class="form-text">
      Must be 8-20 characters long.
    </span>
  </div>
</div>
```

## Form Controls

A classe de `form-control` nos permite personalizar nossos inputs de diversas formas como mudar o tamanho da fonte:

```html
<input class="form-control form-control-lg" type="text" placeholder=".form-control-lg" aria-label=".form-control-lg example">
<input class="form-control" type="text" placeholder="Default input" aria-label="default input example">
<input class="form-control form-control-sm" type="text" placeholder=".form-control-sm" aria-label=".form-control-sm example">
```

Para mais exemplos podemos ir a [documentação](https://getbootstrap.com/docs/5.2/forms/form-control/).

## Form Select

Da mesma forma que o `form-control` trabalha bem com inputs de texto existe a classe `form-select` para personalização de listas:

```html
<select class="form-select" aria-label="Default select example">
  <option selected>Open this select menu</option>
  <option value="1">One</option>
  <option value="2">Two</option>
  <option value="3">Three</option>
</select>
```

## Floating Labels

Podemos também mudar a forma com que os textos de identificação dos campos (labels) são mostrados, para serem flutuantes com a classe `form-floatting`.

```html
<div class="form-floating mb-3">
  <input type="email" class="form-control" id="floatingInput" placeholder="name@example.com">
  <label for="floatingInput">Email address</label>
</div>
<div class="form-floating">
  <input type="password" class="form-control" id="floatingPassword" placeholder="Password">
  <label for="floatingPassword">Password</label>
</div>
```

## Validations

Uma parte importante de formulários são as validações de seus campos. Por exemplo a idade requerida tem que ser maior que 18 ou o email tem que ser válido. 

Algumas dessas validações são possíveis diretamente com os elementos html, outras podem ser personalizadas com javascript. No bootstrap podemos tirar vantagens das 2 abordagens.

Sem validação customizada com javascript cada elemento é validado de forma independente e o primeiro que falhar, a validação já sinalizará o problema:

```html
<form>
    <!-- Campo Nome -->
    <div class="mb-3">
        <label for="nome" class="form-label">Nome</label>
        <input type="text" class="form-control" id="nome" name="nome" required>
        <div class="invalid-feedback">
            Por favor, insira o seu nome.
        </div>
    </div>

    <!-- Campo Idade -->
    <div class="mb-3">
        <label for="idade" class="form-label">Idade</label>
        <input type="number" class="form-control" id="idade" name="idade" min="18" required>
        <div class="invalid-feedback">
            Você deve ter pelo menos 18 anos.
        </div>
    </div>

    <!-- Botão de Enviar -->
    <button type="submit" class="btn btn-primary">Enviar<button>
</form>
```

Caso queiramos customizar a validação com o boostrap devemos a fazer da seguinte forma:

- Criamos o arquivo html com nosso formulário

```html
<form class="row g-3 needs-validation" novalidate>
  <div class="col-md-4">
    <label for="validationCustom01" class="form-label">First name</label>
    <input type="text" class="form-control" id="validationCustom01" value="Mark" required>
    <div class="valid-feedback">
      Looks good!
    </div>
  </div>
  <div class="col-md-4">
    <label for="validationCustom02" class="form-label">Last name</label>
    <input type="text" class="form-control" id="validationCustom02" value="Otto" required>
    <div class="valid-feedback">
      Looks good!
    </div>
  </div>
  <div class="col-md-4">
    <label for="validationCustomUsername" class="form-label">Username</label>
    <div class="input-group has-validation">
      <span class="input-group-text" id="inputGroupPrepend">@</span>
      <input type="text" class="form-control" id="validationCustomUsername" aria-describedby="inputGroupPrepend" required>
      <div class="invalid-feedback">
        Please choose a username.
      </div>
    </div>
  </div>
  <div class="col-md-6">
    <label for="validationCustom03" class="form-label">City</label>
    <input type="text" class="form-control" id="validationCustom03" required>
    <div class="invalid-feedback">
      Please provide a valid city.
    </div>
  </div>
  <div class="col-md-3">
    <label for="validationCustom04" class="form-label">State</label>
    <select class="form-select" id="validationCustom04" required>
      <option selected disabled value="">Choose...</option>
      <option>...</option>
    </select>
    <div class="invalid-feedback">
      Please select a valid state.
    </div>
  </div>
  <div class="col-md-3">
    <label for="validationCustom05" class="form-label">Zip</label>
    <input type="text" class="form-control" id="validationCustom05" required>
    <div class="invalid-feedback">
      Please provide a valid zip.
    </div>
  </div>
  <div class="col-12">
    <div class="form-check">
      <input class="form-check-input" type="checkbox" value="" id="invalidCheck" required>
      <label class="form-check-label" for="invalidCheck">
        Agree to terms and conditions
      </label>
      <div class="invalid-feedback">
        You must agree before submitting.
      </div>
    </div>
  </div>
  <div class="col-12">
    <button class="btn btn-primary" type="submit">Submit form</button>
  </div>
</form>
```

Nele precisamos usar o atributo `novalidate` e a classe `needs-validation` no formulário para podermos identificar o elemento no javascript. 

- Depois criamos o arquivo Javascript

```js
(() => {
  'use strict'

  // Fetch all the forms we want to apply custom Bootstrap validation styles to
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
})()
```

Este código é executado assim que a página é carregada. Ele realiza as seguintes ações:

- Busca no `DOM` todos os elementos que tenham a classe `needs-validation`.
- Faz um loop nesta lista de elementos e pra cada um adiciona uma ação para ser realizada no evento de `submit` através da função `addEventListener`.
- Essa função checa o `form` e ve se ele tem algum erro de validação, se tiver marca o erro.

## Integrando formulários com apis REST

Como visto na aula 13, através da função `fetch` do javascript podemos chamar endpoints de apis através de nossas páginas html.

Podemos realizar a chamada das nossas apis ao usarmos o mesmo evento que adicionamos as ações de validação nos `forms`, o evento `submit`.

Vamos montar o envio de informações de login por exemplo. Primeiro vamos criar a página html.

> [!IMPORTANT] 
> Usaremos a api criada para esta aula na pasta form-api. 

```html
<!doctype html>
<html lang="en">

<head>
  <!-- Required meta tags -->
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">

  <!-- Bootstrap CSS -->
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet"
    integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
  <link href="style.css" rel="stylesheet">

  <title>Hello, world!</title>
</head>

<body>
  <div class="container">
    <form id="LoginForm" class="row g-3 needs-validation" novalidate>
      <div class="form-floating mb-3">
        <input type="email" class="form-control" id="floatingInput" placeholder="name@example.com">
        <label for="floatingInput">Email address</label>
      </div>
      <div class="form-floating">
        <input type="password" class="form-control" id="floatingPassword" placeholder="Password">
        <label for="floatingPassword">Password</label>
      </div>
      <div class="col-12">
        <button class="btn btn-primary" type="submit">Submit form</button>
      </div>
    </form>
  </div>

  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js"
    integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM"
    crossorigin="anonymous"></script>
  <script src="scripts.js"></script>
</body>

</html>
```

Aqui criamos nosso formulário e no final adicionamos nosso arquivo `scripts.js` que vai conter nosso código javascript.

```js
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
```

## Referencias

- [Submit HTML Forms to JSON APIs easily](https://dev.to/amjadmh73/submit-html-forms-to-json-apis-easily-137l)