const start_btn = document.querySelector(".start_quiz");
const quiz_box = document.querySelector(".quiz-box");


start_btn.onclick = () => {
    quiz_box.classList.remove("inactive");
    start_btn.classList.add("inactive");
}