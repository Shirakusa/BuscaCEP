$(document).ready(function () {

    $('#cep-input').on('input', function () {
        this.value = this.value.replace(/[^0-9]/g, '')
    })

    $('#buscar-button').on('click', function () {

        let cep = $('#cep-input').val()

        if (!(cep.length < 8)) {
            window.location.href = `${window.location.href}?cep=${$('#cep-input').val()}`
        }
        else {
            Swal.fire({
                position: 'top-end',
                icon: 'error',
                title: 'Erro',
                text: 'Cep inválido',
                showConfirmButton: false,
                timer: 2500
            })
        }
            
    })
})