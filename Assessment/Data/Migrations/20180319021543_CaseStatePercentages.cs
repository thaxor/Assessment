using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Assessment.Data.Migrations
{
    public partial class CaseStatePercentages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"
                CREATE PROCEDURE [dbo].[spCaseStatePercentages]
                AS
                BEGIN
                    select[UserName]
                          ,100.0 * count([ReviewerForeignKey]) / count(*) 'PercentUserCasesReviewed'
                          ,100.0 * count([ApproverForeignKey]) / count(*) 'PercentUserCasesApproved'
                          ,100.0 * count([ReviewerForeignKey]) / sum(count(*)) over() 'PercentUserTotalCasesReviewed'
                          ,100.0 * count([ApproverForeignKey]) / sum(count(*)) over() 'PercentUserTotalCasesApproved'
                    from Cases c
                    join AspNetUsers anu on anu.id = c.[WorkerForeignKey]
                    group by [UserName], [WorkerForeignKey]
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var drop = "DROP PROCEDURE [dbo].[spCaseStatePercentages];";

            migrationBuilder.Sql(drop);
        }
    }
}
