document.getElementById("calcBtn").addEventListener("click", async () => {
    const incomeEl = document.getElementById("income");
    const resultEl = document.getElementById("result");
    const taxEl = document.getElementById("tax");
    const rateEl = document.getElementById("rate");
    const errorEl = document.getElementById("error");

    const income = parseFloat(incomeEl.value);
    errorEl.style.display = "none";

    if (isNaN(income) || income < 0) {
        errorEl.innerText = "Please enter a valid non-negative income.";
        errorEl.style.display = "block";
        return;
    }

    try {
        const res = await fetch("/api/tax/calculate", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ income })
        });

        if (!res.ok) {
            const err = await res.json();
            errorEl.innerText = err.message || "Calculation error";
            errorEl.style.display = "block";
            return;
        }

        const data = await res.json();
        taxEl.innerText = data.tax.toFixed(2);
        rateEl.innerText = (data.effectiveRate * 100).toFixed(2) + "%";
    } catch (ex) {
        errorEl.innerText = "Network error: " + ex.message;
        errorEl.style.display = "block";
    }
});