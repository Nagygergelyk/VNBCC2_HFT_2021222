let brands = [];
let connection = null;

let brandIdToUpdate = -1;

getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:48507/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("BrandCreated", (user, message) => {
        getdata();
    });

    connection.on("BrandDeleted", (user, message) => {
        getdata();
    });
    connection.on("BrandUpdated", (user, message) => {
        getdata();
    });
    connection.onclose(async () => {
        await start();
    });
    start();

}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};


async function getdata() {
    await fetch('http://localhost:48507/brand')
        .then(x => x.json())
        .then(y => {
            brands = y;
            //console.log(brands);
            display();
        });
}


function display() {
    document.getElementById('resultarea').innerHTML = "";
    brands.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.brandId + "</td><td>" + t.name + "</td><td>" + `<button type="button" onclick="remove(${t.brandId})">Delete</button>`+ `<button type="button" onclick="showupdate(${t.brandId})">Update</button>` + "</td></tr>";
    });
}

function showupdate(id) {
    document.getElementById('brandNameToUpdate').value = brands.find(t => t['brandId'] == id)['name'];
    document.getElementById('update').style.display = 'flex';
    brandIdToUpdate = id;

}

function remove(id) {
    fetch('http://localhost:48507/brand/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function create() {
    let name = document.getElementById('brandName').value;
    fetch('http://localhost:48507/brand', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: name })
        ,
    })
        .then(response => response)
        .then(data =>
        {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
    display();
}

function update() {
    document.getElementById("update").style.display = 'none';
    let name = document.getElementById('brandNameToUpdate').value;

    fetch('http://localhost:48507/brand', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: name ,brandId: brandIdToUpdate})
        ,
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
    display();
}
