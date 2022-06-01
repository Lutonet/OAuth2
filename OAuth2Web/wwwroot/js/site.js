async function getHelp(help = "", element = document.getElementById("helper")) {
    try {
        const response = await fetch("/API/help/" + help, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        });

        let res = await response.text();
        let obj = JSON.parse(res);
        console.log(obj);
        element.innerHTML = `<h5 class="helper_header">${obj.header}</h5>`;
        let arr = obj.bodyText.split("\n");
        arr.map((div) => element.innerHTML += `<div class="helper_body">${div}</div`);
    }
    catch (err) {
        return err;
    }
}

const ValidateEmail = (mail) => /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(mail) ? true : false;
    
const ValidatePassword = (password) => {
    if (password.length < 8) return false;
    if (password == password.toLowerCase()) return false;
    if (password == password.toUpperCase()) return false;
    if (!/\d/.test(password)) return false;
    return true;
}