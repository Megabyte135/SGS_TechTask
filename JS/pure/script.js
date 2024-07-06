const cities = [
    { id: 1, name: 'Алматы' },
    { id: 2, name: 'Астана' },
    { id: 3, name: 'Караганда' }
];

const workshops = [
    { id: 1, cityId: 1, name: 'Аксай-нан' },
    { id: 2, cityId: 1, name: 'Рахат' },
    { id: 3, cityId: 2, name: 'Аматех' },
    { id: 4, cityId: 3, name: 'Акнар' },
    { id: 5, cityId: 3, name: 'Сарыарка' }
];

const employees = [
    { id: 1, workshopId: 1, name: 'Айгуль Утепова' },
    { id: 2, workshopId: 1, name: 'Вольфганг Амадей' },
    { id: 3, workshopId: 2, name: 'Анна Кузнецова' },
    { id: 4, workshopId: 2, name: 'Ольга Серикбай' },
    { id: 5, workshopId: 3, name: 'Жанторе Ерсынов' },
    { id: 6, workshopId: 4, name: 'Азамат Кантай' },
    { id: 7, workshopId: 4, name: 'Чешир Казбек' },
    { id: 8, workshopId: 5, name: 'Нурсултан Аманбай' },
    { id: 9, workshopId: 5, name: 'Малкольм Рейнольдс' },
];

function getSelectedCity(){
    const citySelect = document.getElementById("city");
    const selectedCity = cities.find(city => city.id == citySelect.value);
    return selectedCity;
}

function getSelectedWorkshop(){
    const workshopSelect = document.getElementById("workshop");
    const selectedWorkshop = workshops.find(workshop => workshop.id == workshopSelect.value);
    return selectedWorkshop;
}

function clearElement(element){
    element.innerHTML = '';
}

function populateCities() {
    const citySelect = document.getElementById("city");

    cities.forEach(city => {
        const option = document.createElement("option");
        option.value = city.id;
        option.text = city.name;
        citySelect.appendChild(option);
    });
}

function updateWorkshops() {
    const selectedCity = getSelectedCity();
    const workshopSelect = document.getElementById("workshop");
    clearElement(workshopSelect);

    if (selectedCity) {
        workshops
        .filter(workshop => workshop.cityId == selectedCity.id)
        .forEach(workshop => {
            const option = document.createElement("option");
            option.value = workshop.id;
            option.text = workshop.name;
            workshopSelect.appendChild(option);
        });
    }

    updateEmployees();
}

function updateEmployees() {
    const selectedWorkshop = getSelectedWorkshop();
    const employeeSelect = document.getElementById("employee");
    clearElement(employeeSelect);

    
    if (selectedWorkshop) {
        employees
        .filter(employee => employee.workshopId == selectedWorkshop.id)
        .forEach(employee => {
            const option = document.createElement("option");
            option.value = employee.id;
            option.text = employee.name;
            employeeSelect.appendChild(option);
        });
    }
}

function saveToCookie() {
    const city = document.getElementById("city").value;
    const workshop = document.getElementById("workshop").value;
    const employee = document.getElementById("employee").value;
    const team = document.getElementById("team").value;
    const shift = document.getElementById("shift").value;

    const formData = {
        city,
        workshop,
        employee,
        team,
        shift,
    };

    document.cookie = `cookie=${JSON.stringify(formData)}; path=/;`;
    alert("Данные сохранены в Cookie");
}

document.addEventListener("DOMContentLoaded", () => {
    populateCities();
    updateWorkshops();
});
