let firestations = [];

fetch('http://localhost:26947/firestation')
    .then(response => response.json())
    .then(data => {
        firestations = data;
        console.log(firestations);
        display();
    });

function display() {
    firestations.forEach(firestation => {
        document.getElementById('resultspart').innerHTML +=
            '<tr><td>' + firestation.id + '</td><td>' +
            firestation.name + '</td><td>' + firestation.location + '</td><td>' + firestation.contactInformation + '</td></tr>';
        console.log(firestation.name);
    });
}