// Copyright (c) Aspose 2002-2016. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace GroupDocsTextVisualStudioPlugin.Core
{
    public class GroupDocsComponents
    {
        public static Dictionary<String, GroupDocsComponent> list = new Dictionary<string, GroupDocsComponent>();
        public GroupDocsComponents()
        {
            list.Clear();

            GroupDocsComponent groupdocsText = new GroupDocsComponent();
            groupdocsText.set_downloadUrl("");
            groupdocsText.set_downloadFileName("groupdocs.Text.zip");
            groupdocsText.set_name(Constants.GROUPDOCS_COMPONENT);
            groupdocsText.set_remoteExamplesRepository("https://github.com/groupdocs-Text/GroupDocs.Text-for-.NET.git");
            list.Add(Constants.GROUPDOCS_COMPONENT, groupdocsText);
        }
    }
}
