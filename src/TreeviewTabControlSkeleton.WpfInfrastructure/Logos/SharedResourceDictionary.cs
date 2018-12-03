using System;
using System.Collections.Generic;
using System.Windows;

namespace TreeviewTabControlSkeleton.WpfInfrastructure.Logos
{
    public class SharedResourceDictionary : ResourceDictionary
    {
        private static readonly Dictionary<Uri, ResourceDictionary> sharedDictinaries = new Dictionary<Uri, ResourceDictionary>(10);
        private Uri _sourceUri;

        public new Uri Source
        {
            get
            {
                return this._sourceUri;
            }
            set
            {
                this._sourceUri = value;

                if (!sharedDictinaries.ContainsKey(value))
                {
                    base.Source = value;

                    if (!sharedDictinaries.ContainsKey(value))
                    {
                        sharedDictinaries.Add(value, this);
                    }
                    else
                    {
                        this.MergedDictionaries.Add(sharedDictinaries[value]);
                    }

                }
                else
                {
                    this.MergedDictionaries.Add(sharedDictinaries[value]);
                }
            }
        }

        public static ResourceDictionary GetSharedResourceDictionary(Uri uri)
        {
            sharedDictinaries.TryGetValue(uri, out var resourceDictionary);

            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (resourceDictionary == null)
            {
                resourceDictionary = new ResourceDictionary
                {
                    Source = uri
                };

                if (!sharedDictinaries.ContainsKey(uri))
                {
                    sharedDictinaries.Add(uri, resourceDictionary);
                }
            }

            return resourceDictionary;
        }
    }
}
