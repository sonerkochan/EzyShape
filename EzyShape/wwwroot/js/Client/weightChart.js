document.addEventListener('DOMContentLoaded', function () {
    const weightLabels = window.weightLabels;
    const weightData = window.weightData;

    const ctx = document.getElementById('weightChart')?.getContext('2d');
    if (ctx) {
        window.weightChartInstance = new Chart(ctx, {
            type: 'line',
            data: {
                labels: weightLabels,
                datasets: [{
                    data: weightData,
                    borderColor: '#2051f1',
                    backgroundColor: 'rgba(32, 81, 241, 0.1)',
                    fill: true,
                    tension: 0.4,
                    pointRadius: 5,
                    pointBackgroundColor: '#2051f1'
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
                plugins: {
                    legend: { display: false }
                },
                scales: {
                    y: {
                        beginAtZero: false
                    }
                }
            }
        });
    }
});
