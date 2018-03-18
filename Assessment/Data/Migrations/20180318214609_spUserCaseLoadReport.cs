using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Assessment.Data.Migrations
{
    public partial class spUserCaseLoadReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"
                CREATE PROCEDURE [dbo].[spUserCaseLoadReport]
                AS
                BEGIN
                    WITH
                    WORKER_RECORDS (UserKey, workerCases)
                    AS (
                        select WorkerForeignKey as UserKey, count(WorkerForeignKey)
                        from Cases
                        group by WorkerForeignKey
                    ),
                    REVIEWER_RECORDS (UserKey, ReviewedCases)
                    AS (
                        select ReviewerForeignKey as UserKey, count(ReviewerForeignKey)
                        from Cases
                        where ReviewerForeignKey is not null
                        group by ReviewerForeignKey
                    ),
                    APPROVED_RECORDS (UserKey, ApprovedCases)
                    AS (
                        select ApproverForeignKey as UserKey, count(ApproverForeignKey)
                        from Cases
                        where ApproverForeignKey is not null
                        group by ApproverForeignKey
                    )
                    select anu.UserName, WorkerCases, ReviewedCases, ApprovedCases
                    from (
                        select coalesce(wr.UserKey, rr.UserKey, ar.UserKey) as UserKey,
                            wr.workerCases, rr.ReviewedCases, ar.ApprovedCases
                        from WORKER_RECORDS wr
                        full join REVIEWER_RECORDS rr on rr.UserKey = wr.UserKey
                        full join APPROVED_RECORDS ar on ar.UserKey = wr.UserKey) as UserCounts
                    full join AspNetUsers anu on anu.id = UserCounts.UserKey
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var drop = "DROP PROCEDURE [dbo].[spUserCaseLoadReport];";

            migrationBuilder.Sql(drop);
        }
    }
}
