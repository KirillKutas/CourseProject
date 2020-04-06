$(document).ready(function () {
    var dropZone = $('#drop-area'),
        maxFileSize = 1000000;
    if (typeof (window.FileReader) == 'undefined') {
        dropZone.text('Не поддерживается браузером!');
        dropZone.addClass('error');
    }
    dropZone[0].ondragover = function () {
        dropZone.addClass('hover');
        return false;
    };

    dropZone[0].ondragleave = function () {
        dropZone.removeClass('hover');
        return false;
    };
    dropZone[0].ondrop = function (event) {
        event.preventDefault();
        dropZone.removeClass('hover');
        dropZone.addClass('drop');
        var dt = event.dataTransfer
        var files = dt.files
        files = [...files]
        files.forEach(uploadFile)
        files.forEach(previewFile)
    };
    function previewFile(file) {
        let reader = new FileReader()
        reader.readAsDataURL(file)
        reader.onloadend = function () {
            let img = document.getElementById('img');
            img.src = reader.result;
        }
    }
    function uploadFile(file, i) {
        var url = 'https://api.cloudinary.com/v1_1/coursepoject/image/upload'
        var xhr = new XMLHttpRequest()
        var formData = new FormData()
        xhr.open('POST', url, true)
        xhr.setRequestHeader('X-Requested-With', 'XMLHttpRequest')
        xhr.responseType = 'json';

        xhr.upload.addEventListener("progress", function (event) {
        })

        xhr.addEventListener('readystatechange', function (event) {
            if (xhr.readyState == 4 && xhr.status == 200) {
                let responseObj = xhr.response;
                var fileName = document.getElementById('image')
                fileName.value = responseObj.public_id;
                document.getElementById('mainBut').disabled = false;
            }
            else if (xhr.readyState == 4 && xhr.status != 200) {
            }
        })

        formData.append('upload_preset', 'ou5uxvjr')
        formData.append('file', file,'lol')
        xhr.send(formData)
    }
    
});
function CreateColl() {
    var text = document.getElementById('descript')
    var toText = document.getElementById('Description')
    var topic = document.getElementById('Topics')
    var toTopic = document.getElementById('Topic')
    toTopic.value = topic.options[topic.selectedIndex].text;
    toText.value = text.value;
}