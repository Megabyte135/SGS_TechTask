<template>
    <h2>Выбор смены</h2>
    <form>
        <div class="form-group">
            <label for="city">Город</label>
            <select class="form-control" id="city" v-model="selectedCity" @change="clearWorkshops">
                <option v-for="city in cities" :key="city.id" :value="city.id">{{ city.name }}</option>
            </select>
        </div>
        <div class="form-group">
            <label for="workshop">Цех</label>
            <select class="form-control" id="workshop" v-model="selectedWorkshop" @change="clearEmployees">
                <option v-for="workshop in filteredWorkshops" :key="workshop.id" :value="workshop.id">{{ workshop.name
                    }}</option>
            </select>
        </div>
        <div class="form-group">
            <label for="employee">Сотрудник</label>
            <select class="form-control" id="employee" v-model="selectedEmployee">
                <option v-for="employee in filteredEmployees" :key="employee.id" :value="employee.id">{{ employee.name
                    }}</option>
            </select>
        </div>
        <div class="form-group">
            <label for="team">Бригада</label>
            <select class="form-control" id="team" v-model="selectedTeam">
                <option>Бригада 1</option>
                <option>Бригада 2</option>
                <option>Бригада 3</option>
            </select>
        </div>
        <div class="form-group">
            <label for="shift">Смена</label>
            <select class="form-control" id="shift" v-model="selectedShift">
                <option>Дневная</option>
                <option>Ночная</option>
            </select>
        </div>
        <button type="submit" class="btn btn-primary" @click="saveDataToCookie">Подтвердить</button>
    </form>
</template>

<script>
export default {
    data() {
        return {
            cities: [
                { id: 1, name: 'Алматы' },
                { id: 2, name: 'Астана' },
                { id: 3, name: 'Караганда' }
            ],
            workshops: [
                { id: 1, cityId: 1, name: 'Аксай-нан' },
                { id: 2, cityId: 1, name: 'Рахат' },
                { id: 3, cityId: 2, name: 'Аматех' },
                { id: 4, cityId: 3, name: 'Акнар' },
                { id: 5, cityId: 3, name: 'Сарыарка' }
            ],
            employees: [
                { id: 1, workshopId: 1, name: 'Айгуль Утепова' },
                { id: 2, workshopId: 1, name: 'Вольфганг Амадей' },
                { id: 3, workshopId: 2, name: 'Анна Кузнецова' },
                { id: 4, workshopId: 2, name: 'Ольга Серикбай' },
                { id: 5, workshopId: 3, name: 'Жанторе Ерсынов' },
                { id: 6, workshopId: 4, name: 'Азамат Кантай' },
                { id: 7, workshopId: 4, name: 'Чешир Казбек' },
                { id: 8, workshopId: 5, name: 'Нурсултан Аманбай' },
                { id: 9, workshopId: 5, name: 'Малкольм Рейнольдс' },
            ],
            teams: [
                { id: 1, name: 'Бригада 1' },
                { id: 2, name: 'Бригада 2' }
            ],
            shifts: [
                { id: 1, name: 'Смена 1' },
                { id: 2, name: 'Смена 2' }
            ],
            selectedCity: null,
            selectedWorkshop: null,
            selectedEmployee: null,
            selectedTeam: null,
            selectedShift: null
        }
    },
    computed: {
        filteredWorkshops() {
            return this.workshops.filter(workshop => workshop.cityId === this.selectedCity)
        },
        filteredEmployees() {
            return this.employees.filter(employee => employee.workshopId === this.selectedWorkshop)
        }
    },
    methods: {
        clearWorkshops() {
            this.selectedWorkshop = null;
            this.selectedEmployee = null;
        },
        clearEmployees() {
            this.selectedEmployee = null;
        },
        saveDataToCookie() {
            const city = this.cities.find(city => city.id === this.selectedCity);
            const workshop = this.workshops.find(workshop => workshop.id === this.selectedWorkshop);
            const employee = this.employees.find(employee => employee.id === this.selectedEmployee);
            const team = this.teams.find(team => team.id === this.selectedTeam);
            const shift = this.shifts.find(shift => shift.id === this.selectedShift);

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
    }
}
</script>

<style>
body {
    font-family: 'Arial', sans-serif;
}

.navbar-brand img {
    width: 30px;
    height: 30px;
}

.container {
    max-width: 600px;
}

h2 {
    margin-bottom: 20px;
}
</style>