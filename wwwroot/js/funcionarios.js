import { debounce } from "../js/utils.js"

const createTable = (filteredEmployees) => {
    const tableBody = document.querySelector('#employee-table-body');

    tableBody.innerHTML = '';

    filteredEmployees.forEach((employee) => {
        console.log(employee)

        const row = document.createElement('tr');

        const nameCell = document.createElement('td');
        nameCell.textContent = employee.Nome;

        const emailCell = document.createElement('td');
        emailCell.textContent = employee.Email;

        const telefoneCell = document.createElement('td');
        telefoneCell.textContent = employee.Telefone;

        const permissaoCell = document.createElement('td');
        permissaoCell.textContent = employee.Permissao.Nome;

        const actionsCell = document.createElement('td');

        const editLink = document.createElement('a');
        editLink.textContent = 'Editar';
        editLink.href = `/Funcionarios/Edit?id=${employee.Id}&cpf=${employee.Cpf}&funcional=${employee.Funcional}`;
        editLink.classList.add('action-link');

        const detailsLink = document.createElement('a');
        detailsLink.textContent = 'Detalhes';
        detailsLink.href = `/Funcionarios/Details?id=${employee.Id}&cpf=${employee.Cpf}&funcional=${employee.Funcional}`;
        detailsLink.classList.add('action-link');

        const deleteLink = document.createElement('a');
        deleteLink.textContent = 'Deletar';
        deleteLink.href = `/Funcionarios/Delete?id=${employee.Id}&cpf=${employee.Cpf}&funcional=${employee.Funcional}`;
        deleteLink.classList.add('action-link');

        actionsCell.appendChild(editLink);
        actionsCell.appendChild(detailsLink);
        actionsCell.appendChild(deleteLink);

        row.appendChild(nameCell);
        row.appendChild(emailCell);
        row.appendChild(telefoneCell);
        row.appendChild(permissaoCell);
        row.appendChild(actionsCell);

        tableBody.appendChild(row);
    });
};

const getEmployees = async () => {
    const response = await fetch('/Funcionarios/GetAllEmployees')
    const jsonResponse = await response.json()

    return jsonResponse;
}

const filterEmployeesByName = async (searchTherm) => {
    const employees = (await getEmployees()).$values;

    console.log(employees)

    //return employees.filter(({ Nome }) => {
    //    const employeeName = Nome.toLowerCase();
    //    const lowerCaseSearchTherm = searchTherm.toLowerCase()

    //    return employeeName.includes(lowerCaseSearchTherm)
    //})
}

const handleInputChanges = debounce(async (event) => {
    const inputElement = event.target
    const searchTherm = inputElement.value
    const filteredEmployees = await filterEmployeesByName(searchTherm)

    //createTable(filteredEmployees)
}, 300)

window.onload = () => {
    const searchInput = document.querySelector('#search')
    searchInput.addEventListener('input', handleInputChanges);
}