using System;
namespace Simedia.App.SDK.Models
{
    public enum Attachment_Type
    {
        project_planning_documents = 1,
        progress_reports = 2,
        invoices = 3,
        test_protocols__data__analisys_and_conclusions = 4,
        design_of_experiments = 5,
        photographs_and_videos = 6,
        project_records__laboratory_notebooks = 7,
        emails = 8,
        design__system_architecture__and_source_code = 9,
        contracts = 10,
        records__results_of_trials_runs = 11
    }

    public enum Attachment_File_Type
    {
        Image,
        Video,
        Document
    }
}
