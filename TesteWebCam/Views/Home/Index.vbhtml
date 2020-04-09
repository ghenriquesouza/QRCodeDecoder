@Code
    ViewData("Title") = "Home Page"
End Code

<div class="row">
    <div class="col-lg-6">
        <video class="videostream" autoplay="" width="360" height="360"></video>
    </div>
    <div class="col-lg-6">
        <img id="screenshot-img" >
    </div>
</div>

<div class="row">
    <button class="capture-button">Capture video</button>
    <button id="screenshot-button">Take screenshot</button>
    <button id="btnLimpa">limpa imagem</button>
</div>


<script type="text/javascript">
    const constraints = {
        video: true
    };

    const videostream = document.querySelector('.videostream');

    navigator.mediaDevices.getUserMedia(constraints).
        then((stream) => { videostream.srcObject = stream });


    const captureVideoButton =
        document.querySelector('#screenshot .capture-button');

    const screenshotButton = document.querySelector('#screenshot-button');
    const img = document.querySelector('#screenshot-img');
    const video = document.querySelector('#screenshot video');

    const canvas = document.createElement('canvas');


    $(document).ready(function () {

        $('#btnLimpa').click(function () {
            img.src = '';
        });

        $('#screenshot-button').click(function () {
            var imagemBase64;
            if (!img.src) {
                canvas.width = videostream.videoWidth;
                canvas.height = videostream.videoHeight;
                canvas.getContext('2d').drawImage(videostream, 0, 0);
                // Other browsers will fall back to image/png
                img.src = canvas.toDataURL();
                imagemBase64 = canvas.toDataURL().replace(/^data:image\/(png);base64,/, "");
            } else
                imagemBase64 = img.src.replace(/^data:image\/(png);base64,/, "");

            $.ajax({
                type: "POST",
                dataType: 'JSON',
                url:' @Url.Action("UploadImagem", "Home")' ,
                data: { imagem: imagemBase64 },
                success: function (data) {
                    alert(data);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(errorThrown);
                }
            });

        })

    });


</script>