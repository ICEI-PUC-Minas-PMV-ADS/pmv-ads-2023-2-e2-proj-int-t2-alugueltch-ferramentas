import { debounce, formatPhoneNumber } from "../js/utils.js"


const formatClientAddress = ({logradouro, numero, bairro}) => {
    return `${logradouro}, ${numero}, ${bairro}` 
}

const createActionLink = (title='', iconClassesArray = [], baseURL = '', cliente) => {
    const url = `${baseURL}?id=${cliente.Id}&cpf=${cliente.Cpf}&funcional=${cliente.Funcional}`;
    const iconTag = `<i class="${iconClassesArray.join(' ')}" title="${title}"></i>`;

    return `<a href="${url}" class="action-link">${iconTag}</a>`;
}

const createTable = (clientsArray) => {
    const tableBody = document.querySelector('#client-table-body');
    tableBody.innerHTML = '';

    let rows = clientsArray.map((client) => {
        const row = document.createElement('tr');
        const { nome, email, endereco, telefone } = client;

        row.innerHTML = `
            <td>${nome}</td>
            <td>${formatClientAddress(endereco)}</td>
            <td>${email}</td>
            <td>${formatPhoneNumber(telefone)}</td>
            <td>Em desenvolvimento</td>
            <td class="table-actions d-flex gap-2">
                ${createActionLink('Editar',['bi', 'bi-pencil-square'], '/Clientes/Edit', client)}
                ${createActionLink('Detalhes',['bi', 'bi-info-circle'], '/Clientes/Details', client)}
                ${createActionLink('Excluir',['bi', 'bi-trash'], '/Clientes/Delete', client)}
            </td>
        `;

        return row;
    });

    if(!rows.length) {
        const emptyRow = document.createElement('tr')

        emptyRow.innerText = 'Nenhum Cliente Cadastrado'
        rows = [emptyRow];
    }

    tableBody.append(...rows);
};

const getClientsByName = async (searchTherm) => {
    const response = await fetch(`/api/clientesapi/${searchTherm}`)
    const jsonResponse = await response.json()

    return jsonResponse;
}

const handleInputChanges = debounce(async (event) => {
    const inputElement = event.target
    const searchTherm = inputElement.value
    const clients = await getClientsByName(searchTherm)

    createTable(clients)
}, 300)

window.onload = () => {
    const searchInput = document.querySelector('#search-input')

    searchInput.addEventListener('input', handleInputChanges)
}