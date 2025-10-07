/**
 * Search-only client: no listing, only query by tracking number.
 * English comments only in code (per requirement).
 */

const API_BASE = ""; // same origin

/** Format ISO date to readable UTC string */
function fmtUTC(iso) {
  try { return new Date(iso).toISOString().replace('T',' ').replace('Z',' UTC'); }
  catch { return iso || "-"; }
}

/** Map status to a colored label */
function renderStatus(status) {
  const s = (status || "").toLowerCase();
  let color = "";
  if (s.includes("delivered")) color = "color:#b8f6cf";
  else if (s.includes("delayed") || s.includes("held")) color = "color:#ffb8b8";
  else color = "color:#ffe7a8";
  return `<span style="${color}">${status || "-"}</span>`;
}

/** Render details panel with parcel object */
function showDetails(p) {
  document.getElementById("dTracking").textContent = p.trackingNumber || "-";
  document.getElementById("dStatus").innerHTML   = renderStatus(p.status);
  document.getElementById("dLocation").textContent = p.location || "-";
  document.getElementById("dEta").textContent = fmtUTC(p.eta);

  const hist = Array.isArray(p.history) && p.history.length ? p.history.join("\n") : "N/A";
  document.getElementById("dHistory").textContent = hist;

  document.getElementById("details").classList.remove("hidden");
  document.getElementById("empty").classList.add("hidden");
}

/** Clear details and show empty hint */
function showEmpty(msg="Please enter a tracking number and click Search.") {
  document.getElementById("details").classList.add("hidden");
  document.getElementById("empty").classList.remove("hidden");
  document.getElementById("msg").className = "msg muted";
  document.getElementById("msg").textContent = msg;
}

/** Show error message */
function showError(msg) {
  document.getElementById("details").classList.add("hidden");
  document.getElementById("empty").classList.add("hidden");
  document.getElementById("msg").className = "msg error";
  document.getElementById("msg").textContent = msg || "Something went wrong.";
}

/** Execute search */
async function doSearch() {
  const input = document.getElementById("trackingInput");
  const tn = input.value.trim();
  if (!tn) {
    showEmpty("Please enter a tracking number.");
    return;
  }
  document.getElementById("msg").className = "msg muted";
  document.getElementById("msg").textContent = "Searching...";

  try {
    const res = await fetch(`${API_BASE}/api/parcels/${encodeURIComponent(tn)}`);
    if (res.status === 404) {
      const data = await res.json().catch(() => ({}));
      showError(data?.message || "Tracking number not found");
      return;
    }
    if (!res.ok) {
      showError("Request failed.");
      return;
    }
    const parcel = await res.json();
    document.getElementById("msg").textContent = "";
    showDetails(parcel);
  } catch (e) {
    showError("Network error.");
  }
}

/** Wire UI events after DOM ready */
window.addEventListener("DOMContentLoaded", () => {
  document.getElementById("btnSearch").addEventListener("click", doSearch);
  document.getElementById("btnClear").addEventListener("click", () => {
    document.getElementById("trackingInput").value = "";
    showEmpty();
  });
  document.getElementById("trackingInput").addEventListener("keydown", (e) => {
    if (e.key === "Enter") doSearch();
  });
  // initial state
  showEmpty();
});
