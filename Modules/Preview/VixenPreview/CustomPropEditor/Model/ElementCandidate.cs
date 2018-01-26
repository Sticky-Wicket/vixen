﻿using System;
using System.Collections.Generic;
using System.Linq;
using Common.WPFCommon.ViewModel;

namespace VixenModules.Preview.VixenPreview.CustomPropEditor.Model
{
	public class ElementCandidate : BindableBase, IEqualityComparer<ElementCandidate>, IEquatable<ElementCandidate>
	{
	    private List<LightNode> _lights;
	    private List<ElementCandidate> _children;
	    private int _order;

        public ElementCandidate()
		{
			Lights = new List<LightNode>();
            Children = new List<ElementCandidate>();
		}

	    public ElementCandidate(string name):this()
	    {
	        Name = name;
	    }
	    
		public Guid Id { get; protected set; }

	    public string Name { get; set; }

	    public List<ElementCandidate> Children
	    {
	        get { return _children; }
	        set
	        {
	            if (Equals(value, _children)) return;
	            _children = value;
	            OnPropertyChanged("Children");
	        }
	    }

	    public List<LightNode> Lights
		{
			get { return _lights; }
			set
			{
			    if (Equals(value, _lights)) return;
			    _lights = value;
			    OnPropertyChanged("Lights");
			    OnPropertyChanged("IsString");
			}
		}

	    public void AddLight(LightNode lightNode)
	    {
            Lights.Add(lightNode);
	    }

	    public int Order
	    {
	        get { return _order; }
	        set
	        {
	            if (value == _order) return;
	            _order = value;
	            OnPropertyChanged("Order");
	        }
	    }

	    public bool IsString
		{
			get { return _lights.Count > 1; }
		}

	    public bool IsLeaf
	    {
	        get { return !Children.Any(); }
	    }

	    public IEnumerable<ElementCandidate> GetLeafEnumerator()
	    {
	        if (IsLeaf)
	        {
	            // Element is already an enumerable, so AsEnumerable<> won't work.
	            return (new[] { this });
	        }
	        else
	        {
	            return Children.SelectMany(x => x.GetLeafEnumerator());
	        }
	    }

        public bool Equals(ElementCandidate x, ElementCandidate y)
		{
			return y != null && x != null && x.Id == y.Id;
		}

		public int GetHashCode(ElementCandidate obj)
		{
			return obj.Id.GetHashCode();
		}

		public bool Equals(ElementCandidate other)
		{
			return other != null && Id == other.Id;
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

	}
}
