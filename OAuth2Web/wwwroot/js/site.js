async function getHelp(help = "", element = document.getElementById("helper")) {
    try {
        const response = await fetch("/API/help/" + help, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        });

        return response.text();
    }
    catch (err) {
        return err;
    }
}