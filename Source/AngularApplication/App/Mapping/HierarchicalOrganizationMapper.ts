"use strict";

module ServiceRegister
{
    export class HierarchicalOrganizationMapper
    {
        public static map(data: any): Array<HierarchicalOrganization>
        {
            var result: Array<HierarchicalOrganization> = new Array<HierarchicalOrganization>();
            data.forEach((item: any) =>
            {
                var names: Array<LocalizedText> = LocalizedTextMapper.map(item.names);
                result.push(new HierarchicalOrganization(item.id, names, this.map(item.subOrganizations)));
            });
            return result;
        }
    }
} 