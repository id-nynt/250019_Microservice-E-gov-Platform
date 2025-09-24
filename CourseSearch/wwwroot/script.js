document.getElementById("searchBtn").addEventListener("click", doSearch);

async function doSearch() {
    const keyword = document.getElementById("keyword").value.trim();
    const location = document.getElementById("location").value.trim();
    const area = document.getElementById("area").value;
    const studyOption = document.getElementById("studyOption").value;

    const params = new URLSearchParams();
    if (keyword) params.append("keyword", keyword);
    if (location) params.append("location", location);
    if (area && area !== "Any") params.append("area", area);
    if (studyOption && studyOption !== "Any") params.append("studyOption", studyOption);

    const url = "/api/courses" + (params.toString() ? "?" + params.toString() : "");
    try {
        const res = await fetch(url);
        if (!res.ok) {
            showError("Search failed: " + res.statusText);
            return;
        }
        const list = await res.json();
        renderResults(list);
    } catch (err) {
        showError("Network error: " + err.message);
    }
}

function renderResults(list) {
    const container = document.getElementById("results");
    if (!list || list.length === 0) {
        container.innerHTML = '<p class="no-results">No courses found.</p>';
        return;
    }

    let html = "<table><thead><tr><th>Code</th><th>Course</th><th>Level</th><th>Area</th><th>Location</th><th>Study option</th><th>Duration</th><th>Est. fee (AUD)</th></tr></thead><tbody>";
    for (const c of list) {
        html += `<tr>
      <td>${escapeHtml(c.courseCode)}</td>
      <td>${escapeHtml(c.courseName)}</td>
      <td>${escapeHtml(c.level)}</td>
      <td>${escapeHtml(c.courseArea)}</td>
      <td>${escapeHtml(c.location)}</td>
      <td>${escapeHtml(c.studyOption)}</td>
      <td>${escapeHtml(c.duration)}</td>
      <td>${(c.estimatedFee || 0).toFixed(2)}</td>
    </tr>`;
    }
    html += "</tbody></table>";
    container.innerHTML = html;
}

function showError(msg) {
    const container = document.getElementById("results");
    container.innerHTML = `<p class="no-results">${escapeHtml(msg)}</p>`;
}

function escapeHtml(str) {
    if (!str) return "";
    return String(str).replace(/[&<>"']/g, (m) => ({ '&': '&amp;', '<': '&lt;', '>': '&gt;', '"': '&quot;', "'": '&#39;' }[m]));
}