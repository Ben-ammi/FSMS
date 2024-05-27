document.addEventListener('DOMContentLoaded', function() {
    // Define the URL for fetching the data
    const url = '/FuelLevels/Index';
    
    // Fetch the data from the backend
    fetch(url)
        .then(response => response.json())
        .then(data => {
            // Function to update dispenser data
            const updateDispenser = (dispenserId, dispenserName) => {
                const dispenserData = data.find(d => d.TankName === dispenserName);
                if (dispenserData) {
                    document.getElementById(`${dispenserId}-title`).textContent = `Fuel Level: ${dispenserData.Level}%`;
                    document.getElementById(`${dispenserId}-content`).textContent = `Last updated: ${new Date(dispenserData.LastUpdated).toLocaleString()}`;
                } else {
                    document.getElementById(`${dispenserId}-content`).textContent = 'No data available';
                }
            };

            // Update each dispenser
            updateDispenser('dispenser1', 'Dispenser 1');
            updateDispenser('dispenser2', 'Dispenser 2');
            updateDispenser('dispenser3', 'Dispenser 3');
        })
        .catch(error => {
            console.error('Error fetching fuel levels:', error);
            ['dispenser1', 'dispenser2', 'dispenser3'].forEach(dispenserId => {
                document.getElementById(`${dispenserId}-content`).textContent = 'Error loading data';
            });
        });
});