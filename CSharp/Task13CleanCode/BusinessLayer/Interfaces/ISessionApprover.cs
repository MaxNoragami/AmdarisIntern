﻿using BusinessLayer.Entities;

namespace BusinessLayer.Interfaces;

public interface ISessionApprover
{
    public void ApproveSession(List<Session> sessions);
}
