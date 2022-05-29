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