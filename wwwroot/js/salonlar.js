function showSalonDetails(salonId) {
    fetch(`/Randevu/GetSalonDetails/${salonId}`)
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            const modal = document.getElementById('salonModal');
            const salonBilgileri = document.getElementById('salonBilgileri');
            
            let html = `<h2>${data.salon.ad}</h2>
                       <p>Çalışma Saatleri: ${formatTime(data.salon.acilis_saati)} - ${formatTime(data.salon.kapanis_saati)}</p>`;
            
            data.calisanlar.forEach(calisan => {
                html += `
                    <div class="calisan-card">
                        <h3>${calisan.ad}</h3>
                        <p>Uzmanlık: ${calisan.uzmanlik}</p>
                        <div class="hizmetler">
                            <h4>Sunduğu Hizmetler:</h4>
                            <ul>
                            ${calisan.hizmetler.map(hizmet => `
                                <li>
                                    ${hizmet.ad} - ${hizmet.fiyat}₺ (${hizmet.sure} dk)
                                    <a href="/Randevu/RandevuOlustur?salonId=${data.salon.id}&calisanId=${calisan.id}&hizmetId=${hizmet.id}" 
                                       class="btn btn-primary btn-sm ms-2">Randevu Al</a>
                                </li>
                            `).join('')}
                            </ul>
                        </div>
                    </div>
                `;
            });

            salonBilgileri.innerHTML = html;
            modal.style.display = "block";
        })
        .catch(error => {
            console.error('Error:', error);
            alert('Salon bilgileri alınırken bir hata oluştu.');
        });
}

function formatTime(timeString) {
    const [hours, minutes] = timeString.split(':');
    return `${hours}:${minutes}`;
}

// Modal kapatma işlevi
document.querySelector('.close').onclick = function() {
    document.getElementById('salonModal').style.display = "none";
}

window.onclick = function(event) {
    const modal = document.getElementById('salonModal');
    if (event.target == modal) {
        modal.style.display = "none";
    }
} 