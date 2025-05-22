// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll('.livro-card').forEach(function (card) {
        card.addEventListener('click', function (e) {
            // Evita navegação se clicar no botão
            if (e.target.tagName === 'A') e.preventDefault();

            var titulo = card.getAttribute('data-titulo') || '';
            var descricao = card.getAttribute('data-descricao') || 'Descrição não disponível.';
            var avaliacao = card.getAttribute('data-avaliacao') || 'Sem avaliação.';

            document.getElementById('livroModalLabel').textContent = titulo;
            document.getElementById('livroDescricao').textContent = descricao;
            document.getElementById('livroAvaliacao').textContent = "Avaliação: " + avaliacao;

            var modal = new bootstrap.Modal(document.getElementById('livroModal'));
            modal.show();
        });
    });
});
