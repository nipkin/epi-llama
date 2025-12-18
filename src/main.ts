import './style.css'

document.addEventListener('DOMContentLoaded', () => {
    const form = document.querySelector<HTMLFormElement>('.content-page__form');
    const resultContainer = document.querySelector<HTMLDivElement>('.content-page__analysis');
    const textarea = document.getElementById("userInput") as HTMLTextAreaElement;

    if (!form) return;

    form.addEventListener('submit', async (event) => {
        event.preventDefault();

        const formData = new FormData(form);
        const userInput = formData.get('userInput')?.toString() ?? '';

        let resultDiv = resultContainer;
        if (!resultDiv) {
            resultDiv = document.createElement('div');
            resultDiv.className = 'content-page__analysis';
            form.insertAdjacentElement('afterend', resultDiv);
        }

        resultDiv.innerHTML = `<div class='loader mx-auto mb-7'></div>
                               <div class='loading mx-auto text-center'>Analyzing your question...</div>`;

        try {
            const response = await fetch(form.action || window.location.href, {
                method: 'POST',
                headers: {
                    'X-Requested-With': 'XMLHttpRequest',
                    'Content-Type': 'application/x-www-form-urlencoded',
                    'RequestVerificationToken': (form.querySelector('input[name="__RequestVerificationToken"]') as HTMLInputElement)?.value ?? ''
                },
                body: new URLSearchParams({ userInput })
            });

            if (!response.ok) {
                throw new Error(`HTTP ${response.status}`);
            }

            const html = await response.text();

            const parser = new DOMParser();
            const newDoc = parser.parseFromString(html, 'text/html');
            const newResult = newDoc.querySelector('.content-page__analysis') as HTMLDivElement | null;

            if (newResult) {
                resultDiv.innerHTML = newResult.innerHTML;
                document.getElementById('resultHeading').innerText = userInput;
                textarea.value = '';
            } else {
                resultDiv.innerHTML = `<div class='error'>No analysis result returned.</div>`;
            }
        } catch (err) {
            console.error(err);
            resultDiv.innerHTML = `<div class='error'>An error occurred while analyzing. Please try again.</div>`;
        }
    });

    textarea.addEventListener("keydown", (event) => {
        if (event.key === "Enter" && !event.shiftKey) {
            event.preventDefault();
            form.requestSubmit();
        }
    });
});