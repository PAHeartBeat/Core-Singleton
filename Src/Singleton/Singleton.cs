// --------------------------------------------------------------------------------
// <copyright file="Singleton.cs" company="N/A">
// Copyright (c) N/A. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------

/*
Author:			Ankur Ranpariya {iPAHeartBeat}
EMail:			ankur30884@gmail.com
Copyright:		(c) 2017, Ankur Ranpariya {iPAHeartBeat}
Social:			@iPAHeartBeat,
GitHubL			https://www.github.com/PAHeartBeat

Original Source:	N/A
Last Modified: 	Ankur Ranpariya
Contributed By:	N/A

All rights reserved.
Redistribution and use in source and binary forms, with or without modification, are permitted provided that the
following conditions are met:

* Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
* Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
* Neither the name of the [ORGANIZATION] nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.


The above copyright notice and this permission notice shall be included in all copies or substantial portions of the
Software.

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
documentation files (the "Software"), to deal in the Software without restriction, including without limitation the
rights to use, copy, modify, merge, publish, distribute, sub license, and/or sell copies of the Software, and to permit
persons to whom the Software is furnished to do so, subject to the following conditions:

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE
*/
using System;

namespace iPAHeartBeat.Core.Singleton;

/// <summary>
/// Will provide basic singleton feature to any class which are derived from this one.
/// </summary>
/// <typeparam name="TClass">The name of the class which needs to be marked as Singleton.</typeparam>
public abstract class Singleton<TClass>
	where TClass : class {
	/// <summary>
	/// Internal object to provide locking when creating instance of the object via Singleton Accessor Filed "Me".
	/// </summary>
	private static readonly object _locked = new object();

	/// <summary>
	/// Internal static filed to use singleton instance.
	/// </summary>
	private static TClass _instance = null;

	/// <summary>
	/// Initializes a new instance of the <see cref="Singleton{TClass}"/> class.
	/// </summary>
	protected Singleton() {
	}

	/// <summary>
	/// Gets or sets singleton Instance accessor property Me. WIll return a single copy of instance to use member's of the class without creating multiple instances.
	/// </summary>
	public static TClass Me {
		get {
			if (_instance == null) {
				lock (_locked) {
					_instance ??= Activator.CreateInstance(typeof(TClass)) as TClass;
				}
			}

			return _instance;
		}

		protected set
		=> _instance = value;
	}
}
