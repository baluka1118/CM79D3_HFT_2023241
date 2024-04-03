let firestations = [];
let firefighters = [];
let equipments = [];
let emergencycalls = [];
FetchFireStations();
FetchFireFighters();
FetchEquipments();
FetchEmergencyCalls();

let idToUpdate = 0;
const Condition = {
    0: 'New',
    1: 'Good',
    2: 'Fair',
    3: 'Poor',
    4: 'Out of Service'
}

const IncidentType = {
    0: 'Fire',
    1: 'Medical Emergency',
    2: 'Rescue',
    3: 'Hazardous Materials',
    4: 'Natural Disaster',
    5: 'False Alarm',
    6: 'Other'
}
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
            `<button type="button" onclick="removeFS(${firestation.id})">Delete</button>` + '</td><td>' + `<button type="button" onclick="showUpdateFS(${firestation.id})">Update</button>` + '</td></tr>';
        console.log(firestation.name);
    });
}

async function DisplayFireFighters() {
    document.getElementById('ffResults').innerHTML = '';
    firefighters.forEach(firefighter => {
        document.getElementById('ffResults').innerHTML +=
            '<tr><td>' + firefighter.id + '</td><td>' +
            firefighter.firstName + '</td><td>' + firefighter.lastName + '</td><td>' + firefighter.rank + '</td><td>' + firefighter.contactInformation + '</td><td>' + firefighter.fireStation.name + '</td><td>' +
            `<button type="button" onclick="removeFF(${firefighter.id})">Delete</button>` + '</td><td>' + `<button type="button" onclick="showUpdateFF(${firefighter.id})">Update</button>` + '</td></tr>';
        console.log(firefighter.firstName);
    });
}

async function DisplayEquipments() {
    
    document.getElementById('eqResults').innerHTML = '';
    equipments.forEach(equipment => {
        let conditionNum = Number(equipment.condition);
        let condition = Condition[conditionNum];
        document.getElementById('eqResults').innerHTML +=
            '<tr><td>' + equipment.id + '</td><td>' +
            equipment.type + '</td><td>' + condition + '</td><td>' + equipment.firefighter.firstName + ' ' + equipment.firefighter.lastName + '</td><td>' +
            `<button type="button" onclick="removeEQ(${equipment.id})">Delete</button>` + '</td><td>' + `<button type="button" onclick="showUpdateEQ(${equipment.id})">Update</button>` + '</td></tr>';
        console.log(equipment.type);
    });
}

async function DisplayEmergencyCalls() {
    document.getElementById('ecResults').innerHTML = '';
    emergencycalls.forEach(emergencycall => {
        let phone = 'Not given';
        if (emergencycall.callerPhone != null) {
            phone = emergencycall.callerPhone;
        }
        let typeNum = Number(emergencycall.incidentType);
        let type = IncidentType[typeNum];
        document.getElementById('ecResults').innerHTML +=
            '<tr><td>' + emergencycall.id + '</td><td>' +
            emergencycall.callerName + '</td><td>' + phone + '</td><td>' + emergencycall.incidentLocation + '</td><td>' + type + '</td><td>' + emergencycall.dateTime + '</td><td>' + emergencycall.fireStation.name + '</td><td>' +
            `<button type="button" onclick="removeEC(${emergencycall.id})">Delete</button>` + '</td><td>' + `<button type="button" onclick="showUpdateEC(${emergencycall.id})">Update</button>` + '</td></tr>';
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

function showAddFS() {
    document.getElementById('FSAdd').style.display = 'block';
}

function showAddFF() {
    document.getElementById('ffFireStation').innerHTML = '';
    firestations.forEach(firestation => {
        document.getElementById('ffFireStation').innerHTML += '<option value="' + firestation.id + '">' + firestation.name + '</option>';
    });
    document.getElementById('FFAdd').style.display = 'block';
}
function showAddEQ() {
    document.getElementById('eqFirefighter').innerHTML = '';
    firefighters.forEach(firefighter => {
        document.getElementById('eqFirefighter').innerHTML += '<option value="' + firefighter.id + '">' + firefighter.firstName + ' ' + firefighter.lastName + '</option>';
        console.log(firefighter.id);
    });
    document.getElementById('EQAdd').style.display = 'block';
}
function showAddEC() {
    document.getElementById('ECAdd').style.display = 'block';
    firestations.forEach(firestation => {
        document.getElementById('ecFireStation').innerHTML += '<option value="' + firestation.id + '">' + firestation.name + '</option>';
    });
}

function showUpdateFS(id) {
    fireStation = firestations.find(f => f.id == id);
    idToUpdate = id;
    console.log(idToUpdate);
    console.log(fireStation);
    document.getElementById('fsNameU').value = fireStation.name;
    document.getElementById('fsLocationU').value = fireStation.location;
    document.getElementById('fsContactU').value = fireStation.contactInformation;
    document.getElementById('FSUpdate').style.display = 'block';
}
function showUpdateFF(id) {
    idToUpdate = id;
    document.getElementById('FFUpdate').style.display = 'block';
}
function showUpdateEQ(id) {
    idToUpdate = id;
    document.getElementById('EQUpdate').style.display = 'block';
}
function showUpdateEC(id) {
    idToUpdate = id;
    document.getElementById('ECUpdate').style.display = 'block';
}


function clearResults() {
    document.getElementById('MainMenu').style.display = 'none';
    document.getElementById('FireStationsTable').style.display = 'none';
    document.getElementById('FireFightersTable').style.display = 'none';
    document.getElementById('EquipmentsTable').style.display = 'none';
    document.getElementById('EmergencyCallsTable').style.display = 'none';

    document.getElementById('FSAdd').style.display = 'none';
    document.getElementById('FFAdd').style.display = 'none';
    document.getElementById('EQAdd').style.display = 'none';
    document.getElementById('ECAdd').style.display = 'none';
}
//--------------CRUD METHODS BELOW----------------
function addFS() {
    var inputName = document.getElementById('fsName').value;
    var inputLocation = document.getElementById('fsLocation').value;
    var inputContact = document.getElementById('fsContact').value;
    fetch('http://localhost:26947/firestation', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(
            { name: inputName, location: inputLocation, contactInformation: inputContact }
        )
    }).then(response => {
        if (!response.ok) {
            return response.json();
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
        document.getElementById('FSAdd').style.display = 'none';
        FetchFireStations();
    }).catch(error => {
        console.error(error);
        alert(error.message);
    });
    document.getElementById('fsName').value = '';
    document.getElementById('fsLocation').value = '';
    document.getElementById('fsContact').value = '';
}
function updateFS() {
    var inputName = document.getElementById('fsNameU').value;
    var inputLocation = document.getElementById('fsLocationU').value;
    var inputContact = document.getElementById('fsContactU').value;
    fetch('http://localhost:26947/firestation', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(
            { id: idToUpdate, name: inputName, location: inputLocation, contactInformation: inputContact }
        )
    }).then(response => {
        if (!response.ok) {
            return response.json();
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
        document.getElementById('FSUpdate').style.display = 'none';
        FetchFireStations();
    }).catch(error => {
        console.error(error);
        alert(error.message);
    });
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

function addFF() {
    var inputFirstName = document.getElementById('ffFirstName').value;
    var inputLastName = document.getElementById('ffLastName').value;
    var inputRank = document.getElementById('ffRank').value;
    var inputContact = document.getElementById('ffContact').value;
    var inputFireStation = document.getElementById('ffFireStation').value;

    fetch('http://localhost:26947/firefighter', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(
            { firstName: inputFirstName, lastName: inputLastName, rank: inputRank, contactInformation: inputContact, fireStation_ID: inputFireStation }
        )
    }).then(response => {
        if (!response.ok) {
            return response.json();
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
        document.getElementById('FFAdd').style.display = 'none';
        FetchFireFighters();
    }).catch(error => {
        console.error(error);
        alert(error.message);
    });
    document.getElementById('ffFirstName').value  = '';
    document.getElementById('ffLastName').value = '';
    document.getElementById('ffRank').value = '';
    document.getElementById('ffContact').value = '';
    document.getElementById('ffContact').value = '';
}
function updateFF() {

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
function addEQ() {
  //ERRORT DOB
    var inputType = document.getElementById('eqType').value;
    var inputCondition = Number(document.getElementById('eqCondition').value);
    var inputFirefighter = document.getElementById('eqFirefighter').value;
    fetch('http://localhost:26947/equipment', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(
            { type: inputType, condition: inputCondition, firefighter_ID: inputFirefighter }
        )
    }).then(response => {
        if (!response.ok) {
            return response.json();
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
        document.getElementById('EQAdd').style.display = 'none';
        FetchEquipments();
    }).catch(error => {
        console.error(error);
        alert(error.message);
    });
    document.getElementById('eqType').value = '';
    document.getElementById('eqCondition').value = '';
    document.getElementById('eqFirefighter').value = '';
}
function updateEQ() {

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
function addEC() {
    var inputCallerName = document.getElementById('ecCallerName').value;
    var inputCallerPhone = document.getElementById('ecCallerPhone').value;
    var inputIncidentLocation = document.getElementById('ecIncidentLocation').value;
    var inputIncidentType = Number(document.getElementById('ecIncidentType').value);
    var inputDate = document.getElementById('ecDate').value;
    var inputFireStation = document.getElementById('ecFireStation').value;
    fetch('http://localhost:26947/emergencycall', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(
            { callerName: inputCallerName, callerPhone: inputCallerPhone, incidentLocation: inputIncidentLocation, incidentType: inputIncidentType, dateTime: inputDate ,fireStation_ID: inputFireStation }
        )
    }).then(response => {
        if (!response.ok) {
            return response.json();
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
        document.getElementById('ECAdd').style.display = 'none';
        FetchEmergencyCalls();
    }).catch(error => {
        console.error(error);
        alert(error.message);
    });
    document.getElementById('ecCallerName').value = '';
    document.getElementById('ecCallerPhone').value = '';
    document.getElementById('ecIncidentLocation').value = '';
    document.getElementById('ecDate').value = '';
    document.getElementById('ecIncidentType').value = '';
    document.getElementById('ecFireStation').value = '';
}
function updateEC() {

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