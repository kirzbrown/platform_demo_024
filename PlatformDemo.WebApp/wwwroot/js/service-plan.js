function addTimeSheet() {
    const container = document.getElementById('timeSheetsAccordion');
    const index = container.children.length; // Current number of TimeSheets
    const timeSheetHtml = `
                    <div class="accordion-item">
                        <h2 class="accordion-header" id="heading${index + 1}">
                            <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapse${index + 1}" aria-expanded="true" aria-controls="collapse${index + 1}">
                                TimeSheet ${index + 1} <!-- Display 1-based index -->
                            </button>
                        </h2>
                        <div id="collapse${index + 1}" class="accordion-collapse collapse" aria-labelledby="heading${index + 1}" data-bs-parent="#timeSheetsAccordion">
                            <div class="accordion-body">
                                <div class="form-group mb-3">
                                    <label for="ViewModel_TimeSheets_${index}__StartTime">Start Time</label>
                                    <input name="TimeSheets[${index}].StartTime" type="time" class="form-control" />
                                </div>
                                <div class="form-group mb-3">
                                    <label for="ViewModel_TimeSheets_${index}__EndTime">End Time</label>
                                    <input name="TimeSheets[${index}].EndTime" type="time" class="form-control" />
                                </div>
                                <div class="form-group mb-3">
                                    <label for="ViewModel_TimeSheets_${index}__Description">Description</label>
                                    <textarea name="TimeSheets[${index}].Description" class="form-control"></textarea>
                                </div>
                                <button type="button" class="btn btn-danger remove-timeSheet" onclick="removeTimeSheet(this)">Remove TimeSheet</button>
                            </div>
                        </div>
                    </div>`;
    container.insertAdjacentHTML('beforeend', timeSheetHtml);
}

function removeTimeSheet(button) {
    button.closest('.accordion-item').remove();
}

function addTimeSheet() {
    const container = document.getElementById('timeSheetsAccordion');
    const index = container.children.length; // Current number of TimeSheets
    const timeSheetHtml = `
                <div class="accordion-item">
                    <h2 class="accordion-header" id="heading${index + 1}">
                        <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapse${index + 1}" aria-expanded="true" aria-controls="collapse${index + 1}">
                            TimeSheet ${index + 1}
                        </button>
                    </h2>
                    <div id="collapse${index + 1}" class="accordion-collapse collapse show" aria-labelledby="heading${index + 1}" data-bs-parent="#timeSheetsAccordion">
                        <div class="accordion-body">
                            <div class="form-group mb-3">
                                <label for="ViewModel_TimeSheets_${index}__StartTime">Start Time</label>
                                <input name="TimeSheets[${index}].StartTime" type="time" class="form-control" />
                            </div>
                            <div class="form-group mb-3">
                                <label for="ViewModel_TimeSheets_${index}__EndTime">End Time</label>
                                <input name="TimeSheets[${index}].EndTime" type="time" class="form-control" />
                            </div>
                            <div class="form-group mb-3">
                                <label for="ViewModel_TimeSheets_${index}__Description">Description</label>
                                <textarea name="TimeSheets[${index}].Description" class="form-control"></textarea>
                            </div>
                            <button type="button" class="btn btn-danger remove-timeSheet" onclick="removeTimeSheet(this)">Remove TimeSheet</button>
                        </div>
                    </div>
                </div>`;
    container.insertAdjacentHTML('beforeend', timeSheetHtml);
}

function removeTimeSheet(button) {
    button.closest('.accordion-item').remove();
}