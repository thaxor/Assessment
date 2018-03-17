using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Assessment.Data.Migrations
{
    public partial class CaseToApplicationUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WorkerId",
                table: "Cases",
                newName: "WorkerForeignKey");

            migrationBuilder.RenameColumn(
                name: "ReviewerId",
                table: "Cases",
                newName: "ReviewerForeignKey");

            migrationBuilder.RenameColumn(
                name: "ApproverId",
                table: "Cases",
                newName: "ApproverForeignKey");

            migrationBuilder.AlterColumn<string>(
                name: "WorkerForeignKey",
                table: "Cases",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReviewerForeignKey",
                table: "Cases",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApproverForeignKey",
                table: "Cases",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cases_ApproverForeignKey",
                table: "Cases",
                column: "ApproverForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_ReviewerForeignKey",
                table: "Cases",
                column: "ReviewerForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_WorkerForeignKey",
                table: "Cases",
                column: "WorkerForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_AspNetUsers_ApproverForeignKey",
                table: "Cases",
                column: "ApproverForeignKey",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_AspNetUsers_ReviewerForeignKey",
                table: "Cases",
                column: "ReviewerForeignKey",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_AspNetUsers_WorkerForeignKey",
                table: "Cases",
                column: "WorkerForeignKey",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_AspNetUsers_ApproverForeignKey",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_AspNetUsers_ReviewerForeignKey",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_AspNetUsers_WorkerForeignKey",
                table: "Cases");

            migrationBuilder.DropIndex(
                name: "IX_Cases_ApproverForeignKey",
                table: "Cases");

            migrationBuilder.DropIndex(
                name: "IX_Cases_ReviewerForeignKey",
                table: "Cases");

            migrationBuilder.DropIndex(
                name: "IX_Cases_WorkerForeignKey",
                table: "Cases");

            migrationBuilder.RenameColumn(
                name: "WorkerForeignKey",
                table: "Cases",
                newName: "WorkerId");

            migrationBuilder.RenameColumn(
                name: "ReviewerForeignKey",
                table: "Cases",
                newName: "ReviewerId");

            migrationBuilder.RenameColumn(
                name: "ApproverForeignKey",
                table: "Cases",
                newName: "ApproverId");

            migrationBuilder.AlterColumn<string>(
                name: "WorkerId",
                table: "Cases",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReviewerId",
                table: "Cases",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApproverId",
                table: "Cases",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
