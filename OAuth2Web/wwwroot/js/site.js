async function getHelp(help = "", element = document.getElementById("helper")) {
    const response = await fetch("/Helpers/" + help, {
        method: 'GET',
        headers: {
            'Content-Type': 'text/html'
        }
    });
   
    return response.text();
}