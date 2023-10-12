import { debounce, formatPhoneNumber } from "../js/utils.js"


const createActionLink = (title='', iconClassesArray = [], baseURL = '', employee) => {
    const url = `${baseURL}?id=${employee.Id}&cpf=${employee.Cpf}&funcional=${employee.Funcional}`;
    const iconTag = `<i class="${iconClassesArray.join(' ')}" title="${title}"></i>`;

    return `<a href="${url}" class="action-link">${iconTag}</a>`;
}

const createTable = (filteredEmployees) => {
    const tableBody = document.querySelector('#employee-table-body');
    tableBody.innerHTML = '';

    const rows = filteredEmployees.map((employee) => {
        const row = document.createElement('tr');
        const { Nome, Email, Telefone, Permissao } = employee;

        row.innerHTML = `
            <td>${Nome}</td>
            <td>${Email}</td>
            <td>${formatPhoneNumber(Telefone)}</td>
            <td>${Permissao.Nome}</td>
            <td class="table-actions d-flex gap-2">
                ${createActionLink('Editar',['bi', 'bi-pencil-square'], '/Funcionarios/Edit', employee)}
                ${createActionLink('Detalhes',['bi', 'bi-info-circle'], '/Funcionarios/Details', employee)}
                ${createActionLink('Excluir',['bi', 'bi-trash'], '/Funcionarios/Delete', employee)}
            </td>
        `;

        return row;
    });

    tableBody.append(...rows);
};

const getEmployees = async () => {
    const response = await fetch('/Funcionarios/GetAllEmployees')
    const jsonResponse = await response.json()

    return jsonResponse;
}

const filterEmployeesByName = async (searchTherm) => {
    const employees = await getEmployees()

    return employees.filter(({ Nome }) => {
        const employeeName = Nome.toLowerCase();
        const lowerCaseSearchTherm = searchTherm.toLowerCase()

        return employeeName.includes(lowerCaseSearchTherm)
    })
}

const handleInputChanges = debounce(async (event) => {
    const inputElement = event.target
    const searchTherm = inputElement.value
    const filteredEmployees = await filterEmployeesByName(searchTherm)

    createTable(filteredEmployees)
}, 300)

window.onload = () => {
    const searchInput = document.querySelector('#search')

    searchInput.addEventListener('input', handleInputChanges)
}