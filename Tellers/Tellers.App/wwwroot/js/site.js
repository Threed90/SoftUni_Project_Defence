// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function addRating() {
    let spans = document.querySelectorAll("span.fa.fa-star");

    let resultLabel = document.getElementById("ratingStar");
    resultLabel.textContent = 0;

    for (const span of spans) {
        span.addEventListener("mouseover", (e) => {
            let parent = e.currentTarget.parentNode;
            
            if (e.currentTarget.classList.contains("oneStar")) {

                parent.querySelector("span.fa.fa-star.oneStar").classList.add("checked");
            }

            if (e.currentTarget.classList.contains("twoStar")) {

                parent.querySelector("span.fa.fa-star.oneStar").classList.add("checked");
                parent.querySelector("span.fa.fa-star.twoStar").classList.add("checked");
            }

            if (e.currentTarget.classList.contains("threeStar")) {

                parent.querySelector("span.fa.fa-star.oneStar").classList.add("checked");
                parent.querySelector("span.fa.fa-star.twoStar").classList.add("checked");
                parent.querySelector("span.fa.fa-star.threeStar").classList.add("checked");
            }

            if (e.currentTarget.classList.contains("fourStar")) {

                parent.querySelector("span.fa.fa-star.oneStar").classList.add("checked");
                parent.querySelector("span.fa.fa-star.twoStar").classList.add("checked");
                parent.querySelector("span.fa.fa-star.threeStar").classList.add("checked");
                parent.querySelector("span.fa.fa-star.fourStar").classList.add("checked");
            }

            if (e.currentTarget.classList.contains("fiveStar")) {

                parent.querySelector("span.fa.fa-star.oneStar").classList.add("checked");
                parent.querySelector("span.fa.fa-star.twoStar").classList.add("checked");
                parent.querySelector("span.fa.fa-star.threeStar").classList.add("checked");
                parent.querySelector("span.fa.fa-star.fourStar").classList.add("checked");
                parent.querySelector("span.fa.fa-star.fiveStar").classList.add("checked");
            }
        });

        span.addEventListener("mouseout", (e) => {
            let parent = e.currentTarget.parentNode;
            
            if (e.currentTarget.classList.contains("oneStar") && !e.currentTarget.classList.contains("voted")) {

                parent.querySelector("span.fa.fa-star.oneStar").classList.remove("checked");
            }

            if (e.currentTarget.classList.contains("twoStar") && !e.currentTarget.classList.contains("voted")) {

                parent.querySelector("span.fa.fa-star.oneStar").classList.remove("checked");
                parent.querySelector("span.fa.fa-star.twoStar").classList.remove("checked");
            }

            if (e.currentTarget.classList.contains("threeStar") && !e.currentTarget.classList.contains("voted")) {

                parent.querySelector("span.fa.fa-star.oneStar").classList.remove("checked");
                parent.querySelector("span.fa.fa-star.twoStar").classList.remove("checked");
                parent.querySelector("span.fa.fa-star.threeStar").classList.remove("checked");
            }

            if (e.currentTarget.classList.contains("fourStar") && !e.currentTarget.classList.contains("voted")) {

                parent.querySelector("span.fa.fa-star.oneStar").classList.remove("checked");
                parent.querySelector("span.fa.fa-star.twoStar").classList.remove("checked");
                parent.querySelector("span.fa.fa-star.threeStar").classList.remove("checked");
                parent.querySelector("span.fa.fa-star.fourStar").classList.remove("checked");
            }

            if (e.currentTarget.classList.contains("fiveStar") && !e.currentTarget.classList.contains("voted")) {

                parent.querySelector("span.fa.fa-star.oneStar").classList.remove("checked");
                parent.querySelector("span.fa.fa-star.twoStar").classList.remove("checked");
                parent.querySelector("span.fa.fa-star.threeStar").classList.remove("checked");
                parent.querySelector("span.fa.fa-star.fourStar").classList.remove("checked");
                parent.querySelector("span.fa.fa-star.fiveStar").classList.remove("checked");
            }
        });

        span.addEventListener("click", (e) => {
            e.preventDefault();

            let parent = e.currentTarget.parentNode;

            if (e.currentTarget.classList.contains("oneStar")) {
                resultLabel.textContent = 1;
                parent.querySelector("span.fa.fa-star.oneStar").classList.add("checked", "voted");
            }

            if (e.currentTarget.classList.contains("twoStar")) {
                resultLabel.textContent = 2;
                parent.querySelector("span.fa.fa-star.oneStar").classList.add("checked", "voted");
                parent.querySelector("span.fa.fa-star.twoStar").classList.add("checked", "voted");
            }

            if (e.currentTarget.classList.contains("threeStar")) {
                resultLabel.textContent = 3;
                parent.querySelector("span.fa.fa-star.oneStar").classList.add("checked", "voted");
                parent.querySelector("span.fa.fa-star.twoStar").classList.add("checked", "voted");
                parent.querySelector("span.fa.fa-star.threeStar").classList.add("checked", "voted");
            }

            if (e.currentTarget.classList.contains("fourStar")) {
                resultLabel.textContent = 4;
                parent.querySelector("span.fa.fa-star.oneStar").classList.add("checked", "voted");
                parent.querySelector("span.fa.fa-star.twoStar").classList.add("checked", "voted");
                parent.querySelector("span.fa.fa-star.threeStar").classList.add("checked", "voted");
                parent.querySelector("span.fa.fa-star.fourStar").classList.add("checked", "voted");
            }

            if (e.currentTarget.classList.contains("fiveStar")) {
                resultLabel.textContent = 5;
                parent.querySelector("span.fa.fa-star.oneStar").classList.add("checked", "voted");
                parent.querySelector("span.fa.fa-star.twoStar").classList.add("checked", "voted");
                parent.querySelector("span.fa.fa-star.threeStar").classList.add("checked", "voted");
                parent.querySelector("span.fa.fa-star.fourStar").classList.add("checked", "voted");
                parent.querySelector("span.fa.fa-star.fiveStar").classList.add("checked", "voted");
            }

            if (e.currentTarget.classList.contains("oneStar") && e.currentTarget.classList.contains("voted")) {


                parent.querySelector("span.fa.fa-star.twoStar").classList.remove("checked", "voted");
                parent.querySelector("span.fa.fa-star.threeStar").classList.remove("checked", "voted");
                parent.querySelector("span.fa.fa-star.fourStar").classList.remove("checked", "voted");
                parent.querySelector("span.fa.fa-star.fiveStar").classList.remove("checked", "voted");
            }

            if (e.currentTarget.classList.contains("twoStar") && e.currentTarget.classList.contains("voted")) {

                parent.querySelector("span.fa.fa-star.threeStar").classList.remove("checked", "voted");
                parent.querySelector("span.fa.fa-star.fourStar").classList.remove("checked", "voted");
                parent.querySelector("span.fa.fa-star.fiveStar").classList.remove("checked", "voted");
            }

            if (e.currentTarget.classList.contains("threeStar") && e.currentTarget.classList.contains("voted")) {

                parent.querySelector("span.fa.fa-star.fourStar").classList.remove("checked", "voted");
                parent.querySelector("span.fa.fa-star.fiveStar").classList.remove("checked", "voted");
            }

            if (e.currentTarget.classList.contains("fourStar") && e.currentTarget.classList.contains("voted")) {

                parent.querySelector("span.fa.fa-star.fiveStar").classList.remove("checked", "voted")
            }
        });
    }
}
