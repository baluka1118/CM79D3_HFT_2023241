let firestations = [];
let firefighters = [];
let equipments = [];
let emergencycalls = [];
async function FetchFireStations() {
    await fetch('http://localhost:26947/firestation')
        .then(response => response.json())
        .then(data => {
            firestations = data;
        });
}
async function FetchFireFighters() {
    await fetch('http://localhost:26947/firefighter')
        .then(response => response.json())
        .then(data => {
            firefighters = data;
        });
}
async function FetchEquipments() {
    await fetch('http://localhost:26947/equipment')
        .then(response => response.json())
        .then(data => {
            equipments = data;
        });
}
async function FetchEmergencyCalls() {
    await fetch('http://localhost:26947/emergencycall')
        .then(response => response.json())
        .then(data => {
            emergencycalls = data;
        });
}
async function DisplayFireStations() {
    await FetchFireStations();
    firestations.forEach(firestation => {
        document.getElementById('fsResults').innerHTML +=
            '<tr><td>' + firestation.id + '</td><td>' +
            firestation.name + '</td><td>' + firestation.location + '</td><td>' + firestation.contactInformation + '</td></tr>';
        console.log(firestation.name);
    });
}
async function DisplayFireFighters() {
    await FetchFireFighters();
    firefighters.forEach(firefighter => {
        document.getElementById('ffResults').innerHTML +=
            '<tr><td>' + firefighter.id + '</td><td>' +
            firefighter.firstName + '</td><td>' + firefighter.lastName + '</td><td>' + firefighter.rank + '</td><td>' + firefighter.contactInformation + '</td></tr>';
        console.log(firefighter.firstName);
    });
}
async function DisplayEquipments() {
    await FetchEquipments();
    equipments.forEach(equipment => {
        document.getElementById('eqResults').innerHTML +=
            '<tr><td>' + equipment.id + '</td><td>' +
            equipment.type + '</td><td>' + equipment.condition + '</td><td>' + equipment.firefighter.firstName + ' ' + equipment.firefighter.lastName + '</td></tr>';
        console.log(equipment.type);
    });
}

async function DisplayEmergencyCalls() {
    await FetchEmergencyCalls();
    emergencycalls.forEach(emergencycall => {
        document.getElementById('ecResults').innerHTML +=
            '<tr><td>' + emergencycall.id + '</td><td>' +
            emergencycall.callerName + '</td><td>' + emergencycall.callerPhone + '</td><td>' + emergencycall.incidentLocation + '</td><td>' + emergencycall.incidentType + '</td></tr>';
        console.log(emergencycall.callerName);
    });
}
function showMainMenu() {
    clearResults();
    document.getElementById('MainMenu').style.display = 'block';
}
function showFireStations() {
    clearResults();
    DisplayFireStations();
    document.getElementById('FireStationsTable').style.display = 'block';
}

function showFirefighters() {
    clearResults();
    DisplayFireFighters();
    document.getElementById('FireFightersTable').style.display = 'block';
}

function showEquipments() {
    clearResults();
    document.getElementById('EquipmentsTable').style.display = 'block';
    DisplayEquipments();
}

function showEmergencyCalls() {
    clearResults();
    DisplayEmergencyCalls();
    document.getElementById('EmergencyCallsTable').style.display = 'block';
}

function clearResults() {
    
    document.getElementById('MainMenu').style.display = 'none';
    document.getElementById('FireStationsTable').style.display = 'none';
    document.getElementById('FireFightersTable').style.display = 'none';
    document.getElementById('EquipmentsTable').style.display = 'none';
    document.getElementById('EmergencyCallsTable').style.display = 'none';
}
