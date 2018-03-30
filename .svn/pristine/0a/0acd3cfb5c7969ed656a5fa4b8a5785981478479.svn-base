//drow table des mesures
function table_pdf(doc, data_grid,height) {
    return doc.drawTable(data_grid, {
        xstart: 10,
        ystart: 50,
        tablestart: height,
        marginleft: 10,
        xOffset: 20,
        yOffset:10,
        printHeaders: false
    });
}

//drow image header
function header(doc) {
    var imgData = 'data:image/jpeg;base64,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';
    doc.addImage(imgData, "JPEG", 25, 7, 120, 57);
    doc.setFontSize(16);
    doc.setTextColor('#348841');
    doc.text(225, 60, 'Rapport Général');
    doc.setFillColor(0, 0, 0);
    doc.setTextColor('#000000');
    doc.rect(10, 75, 585, 0.5, 'F');//
}
//footer
function footer(doc) {
    doc.page = 1;
//    doc.myText("Centered text", { align: "center" }, 0, 300);
    doc.setTextColor('#000000');
    doc.rect(10, 750, 585, 0.5, 'F');
    doc.setFontSize(10);
    var date = new Date();
    var date_ = (date.toString()).substring(3, 21);
    doc.text(425, 780, 'report generated on : ' + date_);
    doc.text(25, 780, 'Contact : www.Tds@gmail.com ');
    doc.text(260, 780, 'page ' + doc.page);
};