$(document).ready(function () {
    $('#articleDropDown').change(function () {

        $('#articleDesc').empty();

        var selectedArticleId = $(this).val();

        if (selectedArticleId == "")
            return;

        var desc = $('#' + selectedArticleId).text();

        console.log(desc);

        $('#articleDesc').append("<p class='border bg-success text-white' style='padding:30px; border-radius:20px;'>" + desc + "</p>");
    });

    loadDataTable();
});

var dataTable;
var complete = false;

function loadDataTable() {
    dataTable = $('#quizListTable').DataTable({
        "ajax": {
            "url": "/quiz/getallquizzes",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": null},
            
            { "data": "questionText", "width": "20%" },
            { "data": "optionA", "width": "20%" },
            { "data": "optionB", "width": "20%" },
            { "data": "optionC", "width": "20%" },
            { "data": "optionD", "width": "20%" },
            { "data": "optionD", "width": "20%" },
            { "data": "correctAnswer", "width": "20%" },
            
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                        <a class="btn btn-danger text-white" style="cursor:pointer; width: 120px;"
                            onclick=Delete('quiz/Delete?id=${data}')>
                            Delete
                        </a>
                    </div>`;
                },
                "width": "20%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%",
        "columnDefs": [
            {
                "searchable": false,
                "orderable": false,
                "targets": 0
            }
        ],
        "order": [
            [1, 'asc']
        ]
    });

    dataTable.on('order.dt search.dt', function () {
        dataTable.column(0, {
            search: 'applied',
            order: 'applied'
        }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();
}

function Delete(deleteUrl) {
    swal({
        title: "Are you sure to delete the quiz?",
        text: "Once deleted, you will not be able to recover",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        // If user selected yes
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: deleteUrl,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}

function answerOnClick(questionIndex, answer) {
    if (complete == true)
        return;

    var elemList = document.getElementsByClassName("custom+" + questionIndex);

    for (var i=0; i<elemList.length; i++) {
        elemList[i].classList.remove("btn-warning");
    }

    document.getElementById("question+" + questionIndex + '+' + answer).classList.add("btn-warning");

   
}

function CompleteQuiz() {


    //var soundCorrect = new Audio('/image/sound_incorrect.mp3');
    var soundCorrect = new Audio('https://interactive-examples.mdn.mozilla.net/media/cc0-audio/t-rex-roar.mp3');
 
    var elemList = document.getElementsByClassName("btn-warning");
    var right_answers = 0;

    

    for (var i=0; i>=0; i--) {
        var correctAnswer = document.getElementById('correct+' + i).value;
        var givenAnswer = elemList[i].getAttribute("for");

        if (givenAnswer == correctAnswer) {     
            elemList[i].classList.add("btn-dark");
            right_answers++;
            soundCorrect.play();

        }
        else {
            elemList[i].classList.add("btn-danger");
 
        }

        elemList[i].classList.remove("btn-warning");
    }
    console.log(right_answers);
    complete = true;
 }