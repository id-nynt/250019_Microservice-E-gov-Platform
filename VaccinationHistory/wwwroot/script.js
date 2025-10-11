document.getElementById("searchButton").addEventListener("click", searchRecord);

async function searchRecord() {
    const userId = document.getElementById("userIdInput").value.trim();
    const resultDiv = document.getElementById("result");
    resultDiv.innerHTML = "";

    // response for if no user id given
    if (!userId) {
        resultDiv.innerHTML = "<p class='error'>No ID entered</p>";
        return;
    }

    resultDiv.innerHTML = "<p class='loading'>Loading</p>";


    // main code
    try {
        const response = await fetch(`/vaccinationRecord?user=${encodeURIComponent(userId)}`);
        const data = await response.json();

	// writes error information from request
        if (!response.ok) {
            resultDiv.innerHTML = `<p class='error'>${data.error}</p>`;
            return;
        }



	// writes records if records returned
        if (data.records && data.records.length > 0) {
            resultDiv.innerHTML = data.records.map(r => `
                <div class="record">
                    <strong>Type:</strong> ${r.type}<br>
                    <strong>Date:</strong> ${new Date(r.date).toLocaleString()}
                </div>
            `).join("");
        } else {
            resultDiv.innerHTML = `<p class='error'>No records found for this user.</p>`;
        }
    } catch (err) {
        resultDiv.innerHTML = `<p class='error'>Error: ${err.message}</p>`;
    }
}
