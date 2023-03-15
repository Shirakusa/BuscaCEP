$(document).ready(function () {

    $('#estado-select').on('change', function () {

        LimpaSelect('municipio-select', true)
        LimpaSelect('logradouro-select', true)

        $.ajax({
            url: `${apiUrl}Endereco/BuscaMunicipio`,
            data: { uf: $('#estado-select').val() },
            method: 'GET'
        }).done(function (data) {
            if (data.length > 0)
                for (var element of data) {
                    $('#municipio-select').append(`<option value='${element.codigoMunicipio}' id='${element.codigoMunicipio}'>${element.municipio}</option>`)
                }

            $('#municipio-select').attr('disabled', false)
        })
    })

    $('#municipio-select').on('change', function () {

        LimpaSelect('logradouro-select', true)

        $.ajax({
            url: `${apiUrl}Endereco/BuscaLogradouro`,
            data: { codigoMunicipio: $('#municipio-select').val() },
            method: 'GET'
        }).done(function (data) {
            if (data.length > 0) {
                for (var element of data) {
                    $('#logradouro-select').append(`<option value='${element.codigoLogradouro}' id='${element.codigoLogradouro}'>${element.nomeLogradouro}</option>`)
                }

                $('#logradouro-select').attr('disabled', false)
            }
            else
                Swal.fire({
                    position: 'top-end',
                    icon: 'error',
                    title: 'Erro',
                    text: 'Não encontrado logradouros para o município selecionado.',
                    showConfirmButton: false,
                    timer: 2500
                })

        })
    })
})

function BuscaCep() {
    $.ajax({
        url: `${apiUrl}Endereco/BuscaCep`,
        data: {
            estado: $('#estado-select').val(),
            codigoMunicipio: $('#municipio-select').val(),
            codigoLogradouro: $('#logradouro-select').val()
        },
        method: 'GET'
    }).done(function (data) {
        $('#cep-p').html(data.logradouro.cep)
        $('#codLogradouro-p').html(data.logradouro.codigoLogradouro)
        $('#municipio-p').html(data.municipio)
        $('#logradouro-p').html(data.logradouro.nomeLogradouro)
    })
}

function LimpaSelect(selectId, desabilitar = false) {
    $(`#${selectId}`).empty()
    $(`#${selectId}`).append(`<option hidden>Escolha um ${selectId.split("-")[0]}...</option>`)


    if (desabilitar)
        $(`#${selectId}`).attr('disabled', true)
}