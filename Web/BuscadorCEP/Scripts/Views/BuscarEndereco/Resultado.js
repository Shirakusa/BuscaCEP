$(document).ready(function () {
    $.ajax({
        url: `${apiUrl}Endereco/BuscaEndereco`,
        data: { cep: $('#cep-input').val() },
        method: 'GET'
    }).done(function (data) {

        if (data) {
            $('#logradouro-input').val(data.logradouro.endereco)
            $('#municipio-input').val(`${data.municipio} - ${data.unidadeFederativa}`)
            $('#bairro-input').val()

            //Buscar bairro
            $.ajax({
                url: `https://viacep.com.br/ws/${$('#cep-input').val()}/json/`,
                method: 'GET'
            }).done(function (data) {
                $('#bairro-input').val(data.bairro)
            })
        }
        else
            Swal.fire({
                position: 'top-end',
                icon: 'error',
                title: 'Erro',
                text: 'Cep não encontrado.',
                showConfirmButton: false,
                timer: 2500
            })
    })
})