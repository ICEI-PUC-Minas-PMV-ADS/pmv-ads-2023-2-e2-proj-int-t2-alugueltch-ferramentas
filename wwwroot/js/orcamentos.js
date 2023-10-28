/* api/ClientesAPI/var */



const getClients = async (nome) => {

    const response = await fetch(`/API/ClientesAPI/${nome}`)
    const jsonResponse = await response.json()
    return jsonResponse;

}

const obterInputCliente = () => {
    const inputName = document.getElementById("client-input");

    inputName.addEventListener('input', async (event) => {
        const inputValue = event.target.value
        const clientesArray = await getClients(inputValue)
        const dataList = document.getElementById("client-names")

        dataList.innerHTML = ""

        clientesArray.forEach((cliente) => {
            dataList.innerHTML += `<option value="${cliente.nome}"></option>`
        })

    })

    inputName.addEventListener('change', async (event) => {
        const inputValue = event.target.value
        const [dadosCliente] = await getClients(inputValue)

        if (dadosCliente.telefone && dadosCliente.email && dadosCliente.endereco) {
            const telefoneInput = document.getElementById("phone-input")
            telefoneInput.value = dadosCliente.telefone

            const emailInput = document.getElementById("email-input")
            emailInput.value = dadosCliente.email
            const enderecoInput = document.getElementById("adress-input")
            const enderecoCliente = `${dadosCliente.endereco.logradouro}, ${dadosCliente.endereco.numero}`
            enderecoInput.value = enderecoCliente
        }

    })
}




const getTools = async (descricao) => {

    const response = await fetch(`/API/ferramentumsapi?descricao=${descricao}`)
    const jsonResponse = await response.json()
    return jsonResponse;

}

const obterInputFerramenta = () => {
    const inputTools = document.getElementById("tools-input");
    const selectedItemsContainer = document.getElementById("selected-tools-container");
    const saveButton = document.getElementById("save-button");

    let selectedItems = [];

    inputTools.addEventListener('input', async (event) => {
        const inputValue = event.target.value;
        const ferramentasArray = await getTools(inputValue);
        const dataList = document.getElementById("tools-names");

        dataList.innerHTML = "";

        ferramentasArray.forEach((ferramentum) => {
            dataList.innerHTML += `<option value="${ferramentum.descricao}"></option>`;
        });
    });

    saveButton.addEventListener('click', () => {
        const selectedValue = inputTools.value;
        console.log(selectedValue)
        if (selectedValue) {
            selectedItems.push(selectedValue);
            updateSelectedItemsContainer();
            inputTools.value = "";
        }
    });

    function updateSelectedItemsContainer() {
        selectedItemsContainer.innerHTML = "";
        selectedItems.forEach((item) => {
            selectedItemsContainer.innerHTML += `<div>${item}</div>`;
        });
    }
}

window.onload = () => {
    obterInputFerramenta()
    obterInputCliente()
}