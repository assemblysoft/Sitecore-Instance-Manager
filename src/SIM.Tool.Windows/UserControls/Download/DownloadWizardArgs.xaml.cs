﻿namespace SIM.Tool.Windows.UserControls.Download
{
  using System;
  using System.Collections.Generic;
  using System.Collections.ObjectModel;
  using SIM.Pipelines.Processors;
  using SIM.Tool.Base.Profiles;
  using SIM.Tool.Base.Wizards;
  using SIM.Tool.Windows.Pipelines.Download;
  using Sitecore.Diagnostics.InfoService.Client.Model;

  public class DownloadWizardArgs : WizardArgs
  {
    #region Fields

    private readonly List<ProductDownloadInCheckbox> _Products = new List<ProductDownloadInCheckbox>();

    #endregion

    #region Constructors

    public DownloadWizardArgs()
    {
    }

    public DownloadWizardArgs(string username, string password)
    {
      UserName = username;
      Password = password;
    }

    #endregion

    #region Public properties

    public string Cookies { get; set; }

    public ReadOnlyCollection<Uri> Links { get; set; }

    public string Password { get; set; }

    public List<ProductDownloadInCheckbox> Products
    {
      get
      {
        return _Products;
      }
    }

    public IRelease[] Releases { get; set; }
    public UriBasedCollection<long> Sizes { get; set; }
    public string UserName { get; set; }

    #endregion

    #region Public methods

    public override ProcessorArgs ToProcessorArgs()
    {
      return new DownloadArgs(Cookies, Links, ProfileManager.Profile.LocalRepository, Sizes);
    }

    #endregion
  }
}