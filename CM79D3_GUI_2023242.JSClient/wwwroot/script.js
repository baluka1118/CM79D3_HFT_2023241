let firestations = [];
let firefighters = [];
let equipments = [];
let emergencycalls = [];

async function FetchFireStations() {
    await fetch('http://localhost:26947/firestation')
        .then(response => response.json())
        .then(data => {
            firestations = data;
            DisplayFireStations();
        });
}

async function FetchFireFighters() {
    await fetch('http://localhost:26947/firefighter')
        .then(response => response.json())
        .then(data => {
            firefighters = data;
            DisplayFireFighters();
        });
}

async function FetchEquipments() {
    await fetch('http://localhost:26947/equipment')
        .then(response => response.json())
        .then(data => {
            equipments = data;
            DisplayEquipments();
        });
}

async function FetchEmergencyCalls() {
    await fetch('http://localhost:26947/emergencycall')
        .then(response => response.json())
        .then(data => {
            emergencycalls = data;
            DisplayEmergencyCalls();
        });
}

async function DisplayFireStations() {
    document.getElementById('fsResults').innerHTML = '';
    firestations.forEach(firestation => {
        document.getElementById('fsResults').innerHTML +=
            '<tr><td>' + firestation.id + '</td><td>' +
            firestation.name + '</td><td>' + firestation.location + '</td><td>' + firestation.contactInformation + '</td><td>' +
            `<button type="button" onclick="removeFS(${firestation.id})">Delete</button>` + '</td><td>' + `<button type="button" onclick="ShowUpdateFS(${firestation.id})">Update</button>` + '</td></tr>';
        console.log(firestation.name);
    });
}

async function DisplayFireFighters() {
    document.getElementById('ffResults').innerHTML = '';
    firefighters.forEach(firefighter => {
        document.getElementById('ffResults').innerHTML +=
            '<tr><td>' + firefighter.id + '</td><td>' +
            firefighter.firstName + '</td><td>' + firefighter.lastName + '</td><td>' + firefighter.rank + '</td><td>' + firefighter.contactInformation + '</td><td>' +
            `<button type="button" onclick="removeFF(${firefighter.id})">Delete</button>` + '</td><td>' + `<button type="button" onclick="ShowUpdateFF(${firefighter.id})">Update</button>` + '</td></tr>';
        console.log(firefighter.firstName);
    });
}

async function DisplayEquipments() {
    document.getElementById('eqResults').innerHTML = '';
    equipments.forEach(equipment => {
        document.getElementById('eqResults').innerHTML +=
            '<tr><td>' + equipment.id + '</td><td>' +
            equipment.type + '</td><td>' + equipment.condition + '</td><td>' + equipment.firefighter.firstName + ' ' + equipment.firefighter.lastName + '</td><td>' +
            `<button type="button" onclick="removeEQ(${equipment.id})">Delete</button>` + '</td><td>' + `<button type="button" onclick="ShowUpdateEQ(${equipment.id})">Update</button>` + '</td></tr>';
        console.log(equipment.type);
    });
}

async function DisplayEmergencyCalls() {
    document.getElementById('ecResults').innerHTML = '';
    emergencycalls.forEach(emergencycall => {
        document.getElementById('ecResults').innerHTML +=
            '<tr><td>' + emergencycall.id + '</td><td>' +
            emergencycall.callerName + '</td><td>' + emergencycall.callerPhone + '</td><td>' + emergencycall.incidentLocation + '</td><td>' + emergencycall.incidentType + '</td><td>' +
            `<button type="button" onclick="removeEC(${emergencycall.id})">Delete</button>` + '</td><td>' + `<button type="button" onclick="ShowUpdateEC(${emergencycall.id})">Update</button>` + '</td></tr>';
        console.log(emergencycall.callerName);
    });
}

function showMainMenu() {
    clearResults();
    document.getElementById('MainMenu').style.display = 'block';
}

function showFireStations() {
    clearResults();
    FetchFireStations();
    document.getElementById('FireStationsTable').style.display = 'block';
}

function showFirefighters() {
    clearResults();
    FetchFireFighters();
    document.getElementById('FireFightersTable').style.display = 'block';
}

function showEquipments() {
    clearResults();
    FetchEquipments();
    document.getElementById('EquipmentsTable').style.display = 'block';
}

function showEmergencyCalls() {
    clearResults();
    FetchEmergencyCalls();
    document.getElementById('EmergencyCallsTable').style.display = 'block';
}

function clearResults() {
    document.getElementById('MainMenu').style.display = 'none';
    document.getElementById('FireStationsTable').style.display = 'none';
    document.getElementById('FireFightersTable').style.display = 'none';
    document.getElementById('EquipmentsTable').style.display = 'none';
    document.getElementById('EmergencyCallsTable').style.display = 'none';
}

function removeFS(id) {
    // Send a DELETE request to the server to remove the fire station with the given id
    fetch(`http://localhost:26947/firestation/${id}`, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
        body: null
    }).then(response => {
        if (!response.ok) {
            return response.json();
        }
        else {
            FetchFireStations();
        }
    }).then(data => {
        if (data != undefined) {
            console.log(data);
            if (data.msg != undefined) {
                throw new Error(data.msg);
            }
            if (data.status != undefined && data.status != 200) {
                throw new Error(data.title)
            }
        }
    }).catch(error => {
        console.error(error);
        alert(error.message);
    });
}
function removeFF(id) {
    // Send a DELETE request to the server to remove the firefighter with the given id
    fetch(`http://localhost:26947/firefighter/${id}`, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
        body: null
    }).then(response => {
        if (!response.ok) {
            return response.json();
        }
        else {
            FetchFireFighters();
        }
    }).then(data => {
        if (data != undefined) {
            console.log(data);
            if (data.msg != undefined) {
                throw new Error(data.msg);
            }
            if (data.status != undefined && data.status != 200) {
                throw new Error(data.title)
            }
        }
    }).catch(error => {
        console.error(error);
        alert(error.message);
    });
}
function removeEQ(id) {
    // Send a DELETE request to the server to remove the equipment with the given id
    fetch(`http://localhost:26947/equipment/${id}`, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
        body: null
    }).then(response => {
        if (!response.ok) {
            return response.json();
        }
        else {
            FetchEquipments();
        }
    }).then(data => {
        if (data != undefined) {
            console.log(data);
            if (data.msg != undefined) {
                throw new Error(data.msg);
            }
            if (data.status != undefined && data.status != 200) {
                throw new Error(data.title)
            }
        }
    }).catch(error => {
        console.error(error);
        alert(error.message);
    });
}
function removeEC(id) {
    // Send a DELETE request to the server to remove the emergency call with the given id
    fetch(`http://localhost:26947/emergencycall/${id}`, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
        body: null
    }).then(response => {
        if (!response.ok) {
            return response.json();
        }
        else {
            FetchEmergencyCalls();
        }
    }).then(data => {
        if (data != undefined) {
            console.log(data);
            if (data.msg != undefined) {
                throw new Error(data.msg);
            }
            if (data.status != undefined && data.status != 200) {
                throw new Error(data.title)
            }
        }
    }).catch(error => {
        console.error(error);
        alert(error.message);
    });
}