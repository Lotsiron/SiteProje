// Salon istatistiklerini yükle
async function loadSalonIstatistikleri() {
    try {
        const response = await fetch('/api/KuaforApi/salon-istatistikleri');
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        const data = await response.json();
        updateSalonIstatistikleriTable(data);
    } catch (error) {
        console.error('İstatistikler yüklenirken hata:', error);
        alert('İstatistikler yüklenirken bir hata oluştu');
    }
}

// Çalışan performansını yükle
async function loadCalisanPerformans(calisanId) {
    if (!calisanId) return; // Eğer çalışan seçilmediyse işlem yapma

    try {
        const response = await fetch(`/api/KuaforApi/calisan-performans/${calisanId}`);
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        const data = await response.json();
        updatePerformanceChart(data);
    } catch (error) {
        console.error('Performans verileri yüklenirken hata:', error);
        alert('Performans verileri yüklenirken bir hata oluştu');
    }
}

// Popüler hizmetleri yükle
async function loadPopulerHizmetler() {
    try {
        let url = '/api/KuaforApi/populer-hizmetler';
        const baslangic = document.getElementById('baslangicTarihi').value;
        const bitis = document.getElementById('bitisTarihi').value;

        // Tarih filtreleri varsa URL'ye ekle
        if (baslangic && bitis) {
            url += `?baslangic=${baslangic}&bitis=${bitis}`;
        }

        const response = await fetch(url);
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        const data = await response.json();
        updatePopulerHizmetlerTable(data);
    } catch (error) {
        console.error('Hizmet verileri yüklenirken hata:', error);
        alert('Hizmet verileri yüklenirken bir hata oluştu');
    }
}

// Salon istatistikleri tablosunu güncelle
function updateSalonIstatistikleriTable(data) {
    const tbody = document.getElementById('salonIstatistikleriTable').getElementsByTagName('tbody')[0];
    tbody.innerHTML = '';
    
    data.forEach(salon => {
        const row = tbody.insertRow();
        row.insertCell(0).textContent = salon.salonAd;
        row.insertCell(1).textContent = salon.calisanSayisi;
        row.insertCell(2).textContent = salon.randevuSayisi;
        row.insertCell(3).textContent = `${salon.toplamKazanc.toLocaleString('tr-TR')} ₺`;
    });
}

// Popüler hizmetler tablosunu güncelle
function updatePopulerHizmetlerTable(data) {
    const tbody = document.getElementById('populerHizmetlerTable').getElementsByTagName('tbody')[0];
    tbody.innerHTML = '';
    
    data.forEach(hizmet => {
        const row = tbody.insertRow();
        row.insertCell(0).textContent = hizmet.hizmetAdi;
        row.insertCell(1).textContent = hizmet.toplamRandevu;
        row.insertCell(2).textContent = `${hizmet.toplamKazanc.toLocaleString('tr-TR')} ₺`;
        row.insertCell(3).textContent = `${hizmet.ortalamaFiyat.toLocaleString('tr-TR')} ₺`;
    });
}

// Performans grafiğini güncelle
let performansChart = null;
function updatePerformanceChart(data) {
    const ctx = document.getElementById('performansChart').getContext('2d');
    
    if (performansChart) {
        performansChart.destroy();
    }

    performansChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: data.map(d => new Date(d.tarih).toLocaleDateString('tr-TR')),
            datasets: [
                {
                    label: 'Günlük Kazanç (₺)',
                    data: data.map(d => d.toplamKazanc),
                    borderColor: 'rgb(75, 192, 192)',
                    backgroundColor: 'rgba(75, 192, 192, 0.2)',
                    tension: 0.1,
                    yAxisID: 'y'
                },
                {
                    label: 'Randevu Sayısı',
                    data: data.map(d => d.randevuSayisi),
                    borderColor: 'rgb(255, 99, 132)',
                    backgroundColor: 'rgba(255, 99, 132, 0.2)',
                    tension: 0.1,
                    yAxisID: 'y1'
                }
            ]
        },
        options: {
            responsive: true,
            interaction: {
                mode: 'index',
                intersect: false,
            },
            scales: {
                y: {
                    type: 'linear',
                    display: true,
                    position: 'left',
                    title: {
                        display: true,
                        text: 'Kazanç (₺)'
                    }
                },
                y1: {
                    type: 'linear',
                    display: true,
                    position: 'right',
                    title: {
                        display: true,
                        text: 'Randevu Sayısı'
                    },
                    grid: {
                        drawOnChartArea: false
                    }
                }
            }
        }
    });
}

// Sayfa yüklendiğinde çalışacak fonksiyonlar
document.addEventListener('DOMContentLoaded', function() {
    // Tarih alanları için varsayılan değerleri ayarla
    const today = new Date();
    const thirtyDaysAgo = new Date(today);
    thirtyDaysAgo.setDate(today.getDate() - 30);

    document.getElementById('baslangicTarihi').value = thirtyDaysAgo.toISOString().split('T')[0];
    document.getElementById('bitisTarihi').value = today.toISOString().split('T')[0];

    // İstatistikleri yükle
    loadSalonIstatistikleri();
    loadPopulerHizmetler();
}); 