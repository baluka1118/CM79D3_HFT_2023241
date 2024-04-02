fetch('http://localhost:26947/equipment')
    .then(response => response.json())
    .then(data => {
        console.log(data);
    });