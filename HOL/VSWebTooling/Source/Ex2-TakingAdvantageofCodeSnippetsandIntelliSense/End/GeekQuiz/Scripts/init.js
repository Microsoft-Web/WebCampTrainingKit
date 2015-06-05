
    (function () {
        $(document).ready(function () {
            var audioElements = document.getElementsByTagName("audio");
            var len = audioElements.length;
            for (var i = 0; i < len; i++) {
                audioElements[i].play();
            }
        });
    }());
