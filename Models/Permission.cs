using System;
using System.Collections.Generic;

namespace nago_reforged_api.Models;

public partial class Permission
{
    public long Id { get; set; }

    public long RoleId { get; set; }

    public long ProfileId { get; set; }

    public bool? CreateUser { get; set; }

    public bool? ReadUser { get; set; }

    public bool? UpdateUser { get; set; }

    public bool? DeleteUser { get; set; }

    public bool? CreateRoles { get; set; }

    public bool? ReadRoles { get; set; }

    public bool? UpdateRoles { get; set; }

    public bool? DeleteRoles { get; set; }

    public bool? CreateEnterprises { get; set; }

    public bool? ReadEnterprises { get; set; }

    public bool? UpdateEnterprises { get; set; }

    public bool? DeleteEnterprises { get; set; }

    public bool? CreateTurn { get; set; }

    public bool? ReadTurn { get; set; }

    public bool? UpdateTurn { get; set; }

    public bool? DeleteTurn { get; set; }

    public bool? CreateAreas { get; set; }

    public bool? ReadAreas { get; set; }

    public bool? UpdateAreas { get; set; }

    public bool? DeleteAreas { get; set; }

    public bool? CreateMachines { get; set; }

    public bool? ReadMachines { get; set; }

    public bool? UpdateMachines { get; set; }

    public bool? DeleteMachines { get; set; }

    public bool? CreateProducts { get; set; }

    public bool? ReadProducts { get; set; }

    public bool? UpdateProducts { get; set; }

    public bool? DeleteProducts { get; set; }

    public bool? CreateProcesses { get; set; }

    public bool? ReadProcesses { get; set; }

    public bool? UpdateProcesses { get; set; }

    public bool? DeleteProcesses { get; set; }

    public bool? CreateBom { get; set; }

    public bool? ReadBom { get; set; }

    public bool? UpdateBom { get; set; }

    public bool? DeleteBom { get; set; }

    public bool? CreateProviders { get; set; }

    public bool? ReadProviders { get; set; }

    public bool? UpdateProviders { get; set; }

    public bool? DeleteProviders { get; set; }

    public bool? CreateContacts { get; set; }

    public bool? ReadContacts { get; set; }

    public bool? UpdateContacts { get; set; }

    public bool? DeleteContacts { get; set; }

    public bool? CreateServices { get; set; }

    public bool? ReadServices { get; set; }

    public bool? UpdateServices { get; set; }

    public bool? DeleteServices { get; set; }

    public bool? CreateOdp { get; set; }

    public bool? ReadOdp { get; set; }

    public bool? UpdateOdp { get; set; }

    public bool? DeleteOdp { get; set; }

    public bool? CreateReportOdp { get; set; }

    public bool? ReadReportOdp { get; set; }

    public bool? UpdateReportOdp { get; set; }

    public bool? DeleteReportOdp { get; set; }

    public bool? CreateDpnc { get; set; }

    public bool? ReadDpnc { get; set; }

    public bool? UpdateDpnc { get; set; }

    public bool? DeleteDpnc { get; set; }

    public bool? CreateSolutionDpnc { get; set; }

    public bool? ReadSolutionDpnc { get; set; }

    public bool? UpdateSolutionDpnc { get; set; }

    public bool? DeleteSolutionDpnc { get; set; }

    public bool? CreateSchedule { get; set; }

    public bool? ReadSchedule { get; set; }

    public bool? UpdateSchedule { get; set; }

    public bool? DeleteSchedule { get; set; }

    public bool? CreateOc { get; set; }

    public bool? ReadOc { get; set; }

    public bool? UpdateOc { get; set; }

    public bool? DeleteOc { get; set; }

    public bool? CreateOs { get; set; }

    public bool? ReadOs { get; set; }

    public bool? UpdateOs { get; set; }

    public bool? DeleteOs { get; set; }

    public bool? CreatePayments { get; set; }

    public bool? ReadPayments { get; set; }

    public bool? UpdatePayments { get; set; }

    public bool? DeletePayments { get; set; }

    public bool? ReadReports { get; set; }

    public bool? GeneratedReports { get; set; }

    public bool? ReadReception { get; set; }

    public bool? UpdateReception { get; set; }

    public bool? DeleteReception { get; set; }

    public bool? CreateReception { get; set; }

    public virtual Profile Profile { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
