(function () {
    WinJS.Namespace.define("Converters", {
        boolToVisibilityConverter: WinJS.Binding.converter(function (answered) {
            return answered ? "" : "none";
        }),
        inverseBoolToVisibilityConverter: WinJS.Binding.converter(function (answered) {
            return !answered ? "" : "none";
        }),
        showingQuestionToVisibilityConverter: WinJS.Binding.converter(function (state) {
            return state === "showingQuestion" ? "" : "none";
        }),
        showingAnswerToVisibilityConverter: WinJS.Binding.converter(function (state) {
            return state === "showingAnswer" ? "" : "none";
        }),
        loadingToVisibilityConverter: WinJS.Binding.converter(function (state) {
            return state === "loading" ? "" : "none";
        }),
    });
}());