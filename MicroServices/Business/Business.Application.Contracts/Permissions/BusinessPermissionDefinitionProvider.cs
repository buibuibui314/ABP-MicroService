﻿using Business.Localization;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Business.Permissions
{
    public class BusinessPermissionDefinitionProvider: PermissionDefinitionProvider
    {

        public override void Define(IPermissionDefinitionContext context)
        {
            var business = context.AddGroup(BusinessPermissions.Business, L("Business"), MultiTenancySides.Tenant);

            var dictionary = business.AddPermission(BusinessPermissions.DataDictionary.Default, L("DataDictionary"));
            dictionary.AddChild(BusinessPermissions.DataDictionary.Update, L("Edit"));
            dictionary.AddChild(BusinessPermissions.DataDictionary.Delete, L("Delete"));
            dictionary.AddChild(BusinessPermissions.DataDictionary.Create, L("Create"));

            var dictionaryDetail = business.AddPermission(BusinessPermissions.DataDictionaryDetail.Default, L("DataDictionary"));
            dictionaryDetail.AddChild(BusinessPermissions.DataDictionaryDetail.Update, L("Edit"));
            dictionaryDetail.AddChild(BusinessPermissions.DataDictionaryDetail.Delete, L("Delete"));
            dictionaryDetail.AddChild(BusinessPermissions.DataDictionaryDetail.Create, L("Create"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BusinessResource>(name);
        }
    }
}
