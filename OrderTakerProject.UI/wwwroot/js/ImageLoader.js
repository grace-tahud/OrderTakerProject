
document.getElementById('ImageSelector').addEventListener('change', function (event) {
        const file = event.target.files[0];
    const reader = new FileReader();

    reader.onload = function (e) {
            
        const base64Output = document.getElementById('SKUImage');
    base64Output.value = (e.target.result).replace('data:image/jpeg;base64,','');
        };

    reader.readAsDataURL(file);
});


document.getElementById('Update_ImageSelector').addEventListener('change', function (event) {
    const file = event.target.files[0];
    const reader = new FileReader();

    reader.onload = function (e) {

        const base64Output = document.getElementById('Update_SKUImage');
        base64Output.value = (e.target.result).replace('data:image/jpeg;base64,', '');
    };

    reader.readAsDataURL(file);
});
